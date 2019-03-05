﻿using System.IO;
using System.Linq;

namespace MarkLogic.Client.DataService.CodeGen
{
    public sealed partial class CodeGeneratorCSharp : ICodeGenerator
    {
        public CodeGeneratorCSharp()
        {
        }

        public void GenerateService(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
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

        private const string Indent = "    ";
        private static readonly string Indent2 = $"{Indent}{Indent}";
        private static readonly string Indent3 = $"{Indent}{Indent}{Indent}";
        private static readonly string Indent4 = $"{Indent}{Indent}{Indent}{Indent}";
        private static readonly string Indent5 = $"{Indent}{Indent}{Indent}{Indent}{Indent}";

        private static readonly string[] StaticNamespaces = {
            "MarkLogic.Client.DataService",
            "System.Collections.Generic",
            "System.IO",
            "System.Threading.Tasks"
        };

        private static void WriteUsings(Service serviceDecl, Endpoint[] endpointDecls, TextWriter output)
        {
            var reqNs = endpointDecls.SelectMany(e => e.Parameters.Select(p => MatchDataType(p.DataType).DefaultType.Namespace)).Where(ns => !string.IsNullOrWhiteSpace(ns));
            var allNs = StaticNamespaces.Union(reqNs).OrderBy(ns => ns);
            foreach (var ns in allNs)
            {
                output.WriteLine($"using {ns};");
            }
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
        }

        private static void WriteAfterword(TextWriter output)
        {
            output.WriteLine($"{Indent}}}\n}}");
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

            var returnType = endpointDecl.ReturnVoid ? "Task" : $"Task<{GetReturnType(endpointDecl.ReturnValue, endpointDecl.ReturnValue.Multiple)}>";
            var paramList = endpointDecl.Parameters.Select(p => $"{GetParameterType(p, p.Multiple)} {p.Name}");

            output.WriteLine($"{Indent2}public async {returnType} {endpointDecl.FunctionName}({string.Join(", ", paramList)})");
            output.WriteLine($"{Indent2}{{");
            output.WriteLine($"{Indent3}return CreateRequest(\"{endpointDecl.ModuleName}\")");

            if (endpointDecl.RequireSession)
            {
                output.WriteLine($"{Indent4}.WithSession(\"session\")");
            }

            if (endpointDecl.Parameters.Count > 0)
            {
                output.WriteLine($"{Indent4}.WithParameters(");
                for(var i = 0; i < endpointDecl.Parameters.Count; i++)
                {
                    var param = endpointDecl.Parameters[i];
                    output.WriteLine($"{Indent5}new {(param.Multiple ? "MultipleParameter" : "SingleParameter")}<{GetParameterType(param, false)}>(\"{param.Name}\", {param.Nullable.ToString().ToLower()}, {param.Name}, Marshal.{GetMarshalMethod(param)}){(i == endpointDecl.Parameters.Count - 1 ? ")" : ", ")}");
                }
            }

            if (endpointDecl.ReturnVoid)
            {
                output.WriteLine($"{Indent4}.RequestNone();");
            }
            else
            {
                var ret = endpointDecl.ReturnValue;
                output.WriteLine($"{Indent4}.{(endpointDecl.ReturnValue.Multiple ? "RequestMultiple" : "RequestSingle")}<{GetReturnType(endpointDecl.ReturnValue, false)}>({ret.Multiple.ToString().ToLower()}, Unmarshal.{GetUnmarshalMethod(ret)});");
            }

            output.WriteLine($"{Indent2}}}");
        }

        private static string GetReturnType(Return ret, bool isMultiple)
        {
            return GetDataType(ret.DataType, isMultiple, ret.Nullable);
        }

        private static string GetParameterType(Parameter param, bool isMultiple)
        {
            return GetDataType(param.DataType, isMultiple, param.Nullable);
        }

        private static string GetMarshalMethod(Parameter param)
        {
            return MatchDataType(param.DataType).DefaultType.MarshalMethod;
        }

        private static string GetUnmarshalMethod(Return ret)
        {
            return MatchDataType(ret.DataType).DefaultType.UnmarshalMethod;
        }
    }
}
