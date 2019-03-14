using MarkLogic.Client.DataService.CodeGen;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class CodeGenerationTests
    {
        public CodeGenerationTests(ITestOutputHelper output)
        {
            Output = output;
        }

        private ITestOutputHelper Output { get; }

        /// <summary>
        /// Names of assemblies embedded as resources in the current assembly.  These are used for compiling generated source code.
        /// </summary>
        /// <remarks>
        /// Assembly versions:
        /// Net Standard: version 2.0.3
        /// Newtonsoft.Json: 12.0.1
        /// </remarks>
        private static readonly string[] EmbeddedAssemblies = new[]
        {
            "netstandard.dll",
            "Newtonsoft.Json.dll"
        };

        private static IEnumerable<MetadataReference> GetAssemblyReferences()
        {
            var metadataRefs = new List<MetadataReference>();
            foreach(var assyName in EmbeddedAssemblies)
            {
                var assyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"MarkLogic.Client.Tests.Resources.CompilerDeps.{assyName}");
                metadataRefs.Add(MetadataReference.CreateFromStream(assyStream));
            }
            //  assumed present in output artifact directory (aka "bin") and is the current working directory (of the test runner)
            metadataRefs.Add(MetadataReference.CreateFromFile(Path.Join(Directory.GetCurrentDirectory(), "MarkLogic.Client.dll")));

            return metadataRefs;
        }

        private static Assembly BuildAssembly(string sourceCode, ITestOutputHelper output)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var assyName = Guid.NewGuid().ToString();

            var compileOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithAssemblyIdentityComparer(DesktopAssemblyIdentityComparer.Default)
                .WithOptimizationLevel(OptimizationLevel.Debug);
            var compilation = CSharpCompilation.Create(assyName, new[] { syntaxTree }, GetAssemblyReferences(), compileOptions);

            using (var memStream = new MemoryStream())
            {
                var result = compilation.Emit(memStream);
                if (!result.Success)
                {
                    var errors = result.Diagnostics.Where(d => d.IsWarningAsError || d.Severity == DiagnosticSeverity.Error).ToList();
                    output.WriteLine($"\nBuild failed; {errors.Count} errors.");
                    foreach (var error in errors)
                    {
                        output.WriteLine(error.ToString());
                    }
                    throw new ApplicationException("Build failed; view output for errors.");
                }
                memStream.Seek(0, SeekOrigin.Begin);
                return System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromStream(memStream);
            }
        }

        public static string CreateCodeFromPermutations()
        {
            var service = new Service()
            {
                EndpointDirectory = "/path/to/endpoints",
                Description = "Service containing all data type permutations.",
                NetClass = "Test.AllPermutations.DataService",
            };

            var endpoints = new List<Endpoint>();
            foreach (var dataType in CodeGeneratorCSharp.DataTypeMap.Values)
            {
                var dataTypeName = dataType.Name;
                foreach (var mapping in dataType.TypeMappings)
                {
                    var baseName = $"Endpoint_{dataType.Name}_{mapping.TypeFullName.Replace('.', '_')}";
                    var netClass = mapping.TypeFullName;
                    endpoints.AddRange(new[]
                    {
                        CreateEndpoint(baseName, dataTypeName, netClass),
                        CreateEndpoint($"{baseName}_WithSession", dataTypeName, netClass, hasSession: true),
                        CreateEndpoint($"{baseName}_WithNullableSession", dataTypeName, netClass, hasSession: true, nullableSession: true),
                        CreateEndpoint($"{baseName}_MultipleParams", dataTypeName, netClass, isMultipleParams: true),
                        CreateEndpoint($"{baseName}_Multiple", dataTypeName, netClass, isMultiple: true),
                        CreateEndpoint($"{baseName}_Nullable", dataTypeName, netClass, isNullable: true),
                        CreateEndpoint($"{baseName}_MultipleNullable", dataTypeName, netClass, isMultiple: true, isNullable: true),
                        CreateEndpoint($"{baseName}_AllOptions", dataTypeName, netClass, true, true, true, true, true)
                    });
                }
            }

            using (var codeWriter = new StringWriter())
            {
                CodeGeneratorCSharp.Default.GenerateService(service, endpoints.ToArray(), codeWriter);
                return codeWriter.ToString();
            }
        }

        private static Endpoint CreateEndpoint(string funcName, string dataType, string netClass, bool isMultipleParams = false, bool isMultiple = false, bool isNullable = false, bool hasSession = false, bool nullableSession = false)
        {
            var endpoint = new Endpoint() { FunctionName = funcName };

            var paramCount = isMultipleParams ? 3 : 1;
            for (var i = 0; i < paramCount; i++)
            {
                endpoint.Parameters.Add(new Parameter()
                {
                    DataType = dataType,
                    Name = $"param{i}",
                    Multiple = isMultiple,
                    Nullable = isNullable,
                    NetClass = netClass
                });
            }

            if (hasSession)
            {
                endpoint.Parameters.Add(new Parameter()
                {
                    DataType = "session",
                    Name = "session",
                    Nullable = nullableSession
                });
            }

            endpoint.ReturnValue = new Return()
            {
                DataType = dataType,
                Multiple = isMultiple,
                Nullable = isNullable,
                NetClass = netClass
            };

            return endpoint;
        }

        public static readonly string[] StaticServiceDescriptorPathData = new[]
        {
            "../../../../../src/main/ml-modules/root/test",
            "../../../../../src/main/ml-modules/root/test/atomics",
            "../../../../../src/main/ml-modules/root/test/complex"
        };

        public static IEnumerable<object[]> StaticServiceDescriptorPaths() => StaticServiceDescriptorPathData.Select(p => new object[] { p }); 

        [Theory]
        [MemberData(nameof(StaticServiceDescriptorPaths))]
        public async void ServiceFromFile(string pathToService)
        {
            using (var codeWriter = new StringWriter())
            {
                await Code.GenerateService(pathToService, codeWriter, CodeGeneratorCSharp.Default);
                var sourceCode = codeWriter.ToString();
                Output.WriteLine(sourceCode);
                Assert.False(string.IsNullOrWhiteSpace(sourceCode));
            }
        }

        [Theory]
        [MemberData(nameof(StaticServiceDescriptorPaths))]
        public async void CompilableCodeFromDescriptor(string pathToService)
        {
            using (var codeWriter = new StringWriter())
            {
                await Code.GenerateService(pathToService, codeWriter, CodeGeneratorCSharp.Default);
                var sourceCode = codeWriter.ToString();
                Output.WriteLine(sourceCode);
                var assy = BuildAssembly(sourceCode, Output);
                Assert.NotNull(assy);
            }
        }

        [Fact]
        public void CompilableCodeFromPermutations()
        {
            var sourceCode = CreateCodeFromPermutations();
            Output.WriteLine(sourceCode);
            var assy = BuildAssembly(sourceCode, Output);
            Assert.NotNull(assy);
        }
    }
}