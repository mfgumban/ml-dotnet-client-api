using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarkLogic.Client.DataService.CodeGen
{
    internal class ServiceCSharp
    {
        const string Indent = "\t";
        const string Indent2 = "\t\t";
        const string Indent4 = "\t\t\t\t";

        public static void Generate(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            // TODO: validate inputs

            WriteUsings(serviceDecl, endpointDecls, output);
            WritePreamble(serviceDecl, output);
            foreach (var endpointDecl in endpointDecls)
            {
                WriteEndpoint(serviceDecl, endpointDecl, output);
            }
            WriteAfterword(output);
        }

        private static readonly string[] StaticNamespaces = {
            "MarkLogic.Client.DataService",
            "System.Collections.Generic",
            "System.IO",
            "System.Threading.Tasks"
        };

        private static void WriteUsings(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            foreach (var ns in StaticNamespaces)
            {
                output.WriteLine($"using {ns};");
            }
            // TODO: detect use for Newtonsoft.JSON and other optionals
        }

        private static void WritePreamble(Service serviceDecl, TextWriter output)
        {
            output.WriteLine($@"
namespace {serviceDecl.Namespace}
{{
    /// <summary>
    /// {serviceDecl.Description}
    /// </summary>
    public class {serviceDecl.ClassName} : DataServiceBase
    {{
        /// <summary>
        /// Constructs a new {serviceDecl.ClassName} object.
        /// </summary>
        /// <param name=""dbClient"">Client connection to a MarkLogic server.</param>
        protected {serviceDecl.ClassName}(IDatabaseClient dbClient) : base(dbClient, {serviceDecl.EndpointDirectory})
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
        }

        private static void WriteAfterword(TextWriter output)
        {
            output.WriteLine(@"
    }
}");
        }

        private static void WriteEndpoint(Service serviceDecl, Endpoint endpointDecl, TextWriter output)
        {
            output.WriteLine($"{Indent2}/// <summary>");
            output.WriteLine($"{Indent2}/// {endpointDecl.Description}");
            output.WriteLine($"{Indent2}/// </sumary>");
            foreach (var param in endpointDecl.Parameters)
            {
                output.WriteLine($"{Indent2}/// <param name=\"{param.Name}\">{param.Description}</param>");
            }
            output.WriteLine($"{Indent2}/// <returns>{endpointDecl.ReturnValue.Description}</returns>");

            var returnType = GetReturnTypeSyntax(endpointDecl.ReturnValue);
            var paramList = endpointDecl.Parameters.Select(p => $"{GetParameterType(p)} {p.Name}");

            output.WriteLine($@"
        public {returnType} {endpointDecl.FunctionName}({string.Join(", ", paramList)})
        {{
            return CreateRequest(""{endpointDecl.ModuleName}"")");

            if (endpointDecl.RequireSession)
            {
                output.WriteLine($"{Indent4}.WithSession(\"session\")");
            }

                .WithParameters(
                    new SingleParameter<int>("pageLength", true, pageLength, Marshal.Integer),
                    new MultipleParameter<string>("options", true, options, Marshal.String),
                    new SingleParameter<Stream>("doc", true, doc, Marshal.StreamAsXml))
                .RequestMultiple<string>(true, Unmarshal.String);
        }}"
        }

        private static string GetParameterType(Parameter parameter)
        {

        }
    }
}
