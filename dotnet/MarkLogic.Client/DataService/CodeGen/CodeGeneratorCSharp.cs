using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarkLogic.Client.DataService.CodeGen
{
    public sealed partial class CodeGeneratorCSharp : ICodeGenerator
    {
        private static Lazy<CodeGeneratorCSharp> _instance = new Lazy<CodeGeneratorCSharp>(() => new CodeGeneratorCSharp(), true);

        public static CodeGeneratorCSharp Default => _instance.Value;

        public void GenerateService(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            // TODO: validate inputs

            WriteUsings(serviceDecl, endpointDecls, output);
            WritePreamble(serviceDecl, endpointDecls, output);
            foreach (var endpointDecl in endpointDecls)
            {
                WriteEndpoint(serviceDecl, endpointDecl, output);
            }
            WriteAfterword(output);
        }

        private const string Indent = "    ";
        private static readonly string Indent2 = $"{Indent}{Indent}";
        private static readonly string Indent3 = $"{Indent}{Indent}{Indent}";
        private static readonly string Indent4 = $"{Indent}{Indent}{Indent}{Indent}";
        private static readonly string Indent5 = $"{Indent}{Indent}{Indent}{Indent}{Indent}";

        private static readonly string[] StaticNamespaces = {
            "MarkLogic.Client",
            "MarkLogic.Client.DataService",
            "System.Collections.Generic",
            "System.IO",
            "System.Threading.Tasks"
        };

        private static void WriteUsings(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            var reqNs = endpointDecls.SelectMany(e => e.ParametersNoSession.Select(p => GetMapping(p).Namespace)).Where(ns => !string.IsNullOrWhiteSpace(ns));
            var allNs = StaticNamespaces.Union(reqNs).OrderBy(ns => ns);
            foreach (var ns in allNs)
            {
                output.WriteLine($"using {ns};");
            }
        }

        private static void WritePreamble(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            output.WriteLine($@"
namespace {serviceDecl.Namespace}
{{
    /// <summary>
    /// {serviceDecl.Description}
    /// </summary>
    public partial class {serviceDecl.ClassName} : DataServiceBase
    {{
        /// <summary>
        /// Constructs a new {serviceDecl.ClassName} object.
        /// </summary>
        /// <param name=""dbClient"">Client connection to a MarkLogic server.</param>
        protected {serviceDecl.ClassName}(IDatabaseClient dbClient) : base(dbClient, ""{serviceDecl.EndpointDirectory}"")
        {{
        }}

        /// <summary>
        /// Constructs a new {serviceDecl.ClassName} object. 
        /// </summary>
        /// <param name=""dbClient"">Client connection to a MarkLogic server.</param>
        /// <returns>A new {serviceDecl.ClassName} object.</returns>
        public static {serviceDecl.ClassName} Create(IDatabaseClient dbClient)
        {{
            return new {serviceDecl.ClassName}(dbClient);
        }}");

            if (endpointDecls.FirstOrDefault(e => e.HasSession) != null)
            {
                output.WriteLine(@"
        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <returns>A new ISessionState object.</returns>
        public ISessionState NewSession()
        {
            return DbClient.CreateSession();
        }");
            }
        }

        private static void WriteAfterword(TextWriter output)
        {
            output.WriteLine($"{ Indent}}}\n}}");
        }

        private static void WriteEndpoint(Service serviceDecl, Endpoint endpointDecl, TextWriter output)
        {
            output.WriteLine();
            output.WriteLine($"{Indent2}/// <summary>");
            output.WriteLine($"{Indent2}/// {endpointDecl.Description}");
            output.WriteLine($"{Indent2}/// </sumary>");
            foreach (var param in endpointDecl.Parameters)
            {
                output.WriteLine($"{Indent2}/// <param name=\"{param.Name}\">{param.Description}</param>");
            }
            if (!endpointDecl.ReturnVoid)
            {
                output.WriteLine($"{Indent2}/// <returns>{endpointDecl.ReturnValue.Description}</returns>");
            }

            var returnType = endpointDecl.ReturnVoid ? "Task" : $"Task<{GetTypeDeclaration(endpointDecl.ReturnValue)}>";
            var paramList = endpointDecl.Parameters.Select(p => $"{GetParameterType(p)} {p.Name}");

            output.WriteLine($"{Indent2}public {returnType} {endpointDecl.FunctionName}({string.Join(", ", paramList)})");
            output.WriteLine($"{Indent2}{{");
            output.WriteLine($"{Indent3}return CreateRequest(\"{endpointDecl.ModuleName}\")");

            if (endpointDecl.HasSession)
            {
                var sessionParam = endpointDecl.Session;
                output.WriteLine($"{Indent4}.WithSession({sessionParam.Name}, {sessionParam.Nullable.ToString().ToLower()})");
            }

            var parameters = new List<Parameter>(endpointDecl.ParametersNoSession);
            if (parameters.Count > 0)
            {
                output.WriteLine($"{Indent4}.WithParameters(");
                for(var i = 0; i < parameters.Count; i++)
                {
                    var param = endpointDecl.Parameters[i];
                    output.WriteLine($"{Indent5}new {(param.Multiple ? "MultipleParameter" : "SingleParameter")}<{GetParameterType(param, false)}>(\"{param.Name}\", {param.Nullable.ToString().ToLower()}, {param.Name}, {GetMarshalMethod(param)}){(i == parameters.Count - 1 ? ")" : ", ")}");
                }
            }

            if (endpointDecl.ReturnVoid)
            {
                output.WriteLine($"{Indent4}.RequestNone();");
            }
            else
            {
                var ret = endpointDecl.ReturnValue;
                output.WriteLine($"{Indent4}.{(endpointDecl.ReturnValue.Multiple ? "RequestMultiple" : "RequestSingle")}<{GetTypeDeclaration(endpointDecl.ReturnValue, false)}>({ret.Multiple.ToString().ToLower()}, {GetUnmarshalMethod(ret)});");
            }

            output.WriteLine($"{Indent2}}}");
        }

        private static string GetTypeDeclaration(ITypeDeclaration typeDecl, bool allowMultiple = true)
        {
            var mapping = GetMapping(typeDecl);
            var nullableValueType = typeDecl.Nullable && mapping.IsValueType;
            var multiple = allowMultiple && typeDecl.Multiple;
            return $"{(multiple ? "IEnumerable<" : "")}{mapping.TypeName}{(nullableValueType ? "?" : "")}{(multiple ? ">" : "")}";
        }

        private static string GetParameterType(Parameter param, bool allowMultiple = true)
        {
            return param.IsSession ? "ISessionState" : GetTypeDeclaration(param, allowMultiple);
        }

        private static string GetMarshalMethod(ITypeDeclaration typeDecl)
        {
            var mapping = GetMapping(typeDecl);
            var method = mapping.MarshalMethod;
            if (typeDecl.Nullable && mapping.IsValueType)
            {
                method = $"Nullable<{mapping.TypeName}>(Marshal.{method})";
            }
            return $"Marshal.{method}";
        }

        private static string GetUnmarshalMethod(ITypeDeclaration typeDecl)
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