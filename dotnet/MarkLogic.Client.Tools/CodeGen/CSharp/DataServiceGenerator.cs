using System.Collections.Generic;
using System.Linq;

namespace MarkLogic.Client.Tools.CodeGen.CSharp
{
    internal sealed partial class DataServiceGenerator
    {
        public DataServiceGenerator(ServiceDescriptor serviceDesc, IEnumerable<EndpointDescriptor> endpointDescs)
        {
            Service = serviceDesc;
            Endpoints = endpointDescs;
        }

        public ServiceDescriptor Service { get; }

        public IEnumerable<EndpointDescriptor> Endpoints { get; }

        public void WriteTo(IndentedTextWriter output)
        {
            WriteUsings(output);
            WritePreamble(output);
            foreach (var endpoint in Endpoints)
            {
                WriteEndpoint(endpoint, output);
            }
            WriteAfterword(output);
        }

        private void WriteUsings(IndentedTextWriter output)
        {
            var nsList = new List<string>(new[] {
                "MarkLogic.Client",
                "MarkLogic.Client.DataService",
                "System.Threading.Tasks"
            });

            var allTypeDecls = Endpoints.SelectMany(e => e.ParametersNoSession)
                .Cast<ITypeDescriptor>()
                .Union(Endpoints.Where(e => !e.ReturnVoid).Select(e => e.ReturnValue));

            // add any namespaces required by type mappings
            nsList.AddRange(allTypeDecls.Select(t => GetMapping(t).Namespace).Where(ns => !string.IsNullOrWhiteSpace(ns)).Distinct());

            // add generic collections if needed
            if (allTypeDecls.Any(t => t.Multiple))
            {
                nsList.Add("System.Collections.Generic");
            }

            output.WriteLines(nsList.Select(ns => $"using {ns};").Distinct());
        }

        private void WritePreamble(IndentedTextWriter output)
        {
            // begin namespace
            output.WriteLine();
            output.WriteLine($"namespace {Service.Namespace}");
            output.BeginScope();

            // begin class
            output.WriteCommentSummary(Service.Description ?? $"Provides methods to invoke data services in \"{Service.EndpointDirectory}\".");
            output.WriteLine($"public partial class {Service.ClassName} : DataServiceBase");
            output.BeginScope();

            // protected constructor
            output.WriteCommentSummary($"Constructs a new {Service.ClassName} object.");
            output.WriteCommentParam("dbClient", "A client connection to the database server.");
            output.WriteLine($"protected {Service.ClassName}(IDatabaseClient dbClient) : base(dbClient, \"{Service.EndpointDirectory}\")");
            output.BeginScope();
            output.EndScope();

            // create context method
            output.WriteLine();
            output.WriteCommentSummary($"Creates a new service context using the provided client connection.");
            output.WriteCommentParam("dbClient", "A client connection to the database server.");
            output.WriteCommentReturns($"A new {Service.ClassName} object.");
            output.WriteLine($"public static {Service.ClassName} Create(IDatabaseClient dbClient)");
            output.BeginScope();
            output.WriteLine($"return new {Service.ClassName}(dbClient);");
            output.EndScope();

            // create session method
            if (Endpoints.Any(e => e.HasSession))
            {
                output.WriteLine();
                output.WriteCommentSummary("Creates a new session.");
                output.WriteCommentReturns("An ISessionState object representing the newly created session.");
                output.WriteLine("public ISessionState NewSession()");
                output.BeginScope();
                output.WriteLine("return DbClient.CreateSession();");
                output.EndScope();
            }
        }

        private void WriteAfterword(IndentedTextWriter output)
        {
            output.EndScope();
            output.EndScope();
        }

        private static void WriteEndpoint(EndpointDescriptor endpoint, IndentedTextWriter output)
        {
            output.WriteLine();

            // code comments
            output.WriteCommentSummary(endpoint.Description ?? $"Invokes the \"{endpoint.ModuleName}\" data service endpoint.");
            foreach (var param in endpoint.Parameters)
            {
                var paramDesc = param.Description ?? (param.IsSession ? "A session object." : "");
                output.WriteCommentParam(param.ArgumentName, paramDesc);
            }
            if (!endpoint.ReturnVoid)
            {
                output.WriteCommentReturns(endpoint.ReturnValue.Description);
            }

            var returnType = endpoint.ReturnVoid ? "Task" : $"Task<{GetTypeDeclaration(endpoint.ReturnValue)}>";
            var paramList = endpoint.Parameters.Select(p => $"{GetParameterType(p)} {p.ArgumentName}");

            // begin method
            var funcName = endpoint.FunctionName.Capitalize(); // conform to standard code penmanship; TODO: make this an option
            output.WriteLine($"public {returnType} {funcName}({string.Join(", ", paramList)})");
            output.BeginScope();
            output.WriteLine($"return CreateRequest(\"{endpoint.ModuleName}\")");
            output.AddIndent();

            // WithSession
            if (endpoint.HasSession)
            {
                var sessionParam = endpoint.Session;
                output.WriteLine($".WithSession({sessionParam.ArgumentName}, {sessionParam.Nullable.ToString().ToLower()})");
            }

            // WithParameters
            var parameters = new List<ParameterDescriptor>(endpoint.ParametersNoSession);
            if (parameters.Count > 0)
            {
                output.WriteLine($".WithParameters(");
                output.AddIndent();
                for(var i = 0; i < parameters.Count; i++)
                {
                    var param = endpoint.Parameters[i];
                    var paramClass = param.Multiple ? "MultipleParameter" : "SingleParameter";
                    output.WriteLine($"new {paramClass}<{GetParameterType(param, false)}>(\"{param.Name}\", {param.Nullable.ToString().ToLower()}, {param.ArgumentName}, {GetMarshalMethod(param)}){(i == parameters.Count - 1 ? ")" : ", ")}");
                }
                output.RemoveIndent();
            }

            // return request
            output.WriteLine(endpoint.ReturnVoid ?
                ".RequestNone();" :
                $".{(endpoint.ReturnValue.Multiple ? "RequestMultiple" : "RequestSingle")}<{GetTypeDeclaration(endpoint.ReturnValue, false)}>({endpoint.ReturnValue.Multiple.ToString().ToLower()}, {GetUnmarshalMethod(endpoint.ReturnValue)});");
            output.RemoveIndent();

            // end method
            output.EndScope();
        }

        private static TypeMapping GetMapping(ITypeDescriptor typeDecl)
        {
            if (!DataType.All.TryGetValue(typeDecl.DataType, out DataType dt))
            {
                throw new DataTypeException(typeDecl.DataType);
            }
            return dt.GetMapping(typeDecl.NetClass);
        }

        private static string GetTypeDeclaration(ITypeDescriptor typeDecl, bool allowMultiple = true)
        {
            var mapping = GetMapping(typeDecl);
            var nullableValueType = typeDecl.Nullable && mapping.IsValueType;
            var multiple = allowMultiple && typeDecl.Multiple;
            return $"{(multiple ? "IEnumerable<" : "")}{mapping.TypeName}{(nullableValueType ? "?" : "")}{(multiple ? ">" : "")}";
        }

        private static string GetParameterType(ParameterDescriptor param, bool allowMultiple = true)
        {
            return param.IsSession ? "ISessionState" : GetTypeDeclaration(param, allowMultiple);
        }

        private static string GetMarshalMethod(ITypeDescriptor typeDecl)
        {
            var mapping = GetMapping(typeDecl);
            var method = mapping.MarshalMethod;
            if (typeDecl.Nullable && mapping.IsValueType)
            {
                method = $"Nullable<{mapping.TypeName}>(Marshal.{method})";
            }
            return $"Marshal.{method}";
        }

        private static string GetUnmarshalMethod(ITypeDescriptor typeDecl)
        {
            var mapping = GetMapping(typeDecl);
            var method = mapping.UnmarshalMethod;
            if (typeDecl.Nullable && mapping.IsValueType)
            {
                method = $"Nullable(Unmarshal.{method})";
            }
            return $"Unmarshal.{method}";
        }
    }
}