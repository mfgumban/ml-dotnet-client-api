using MarkLogic.Client.Http;
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

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices.CodeGen
{
    public class GenerateCSharpTests
    {
        public GenerateCSharpTests(ITestOutputHelper output)
        {
            Output = output;
        }

        private ITestOutputHelper Output { get; }

        private static Assembly BuildAssembly(string sourceCode, ITestOutputHelper output)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var assyName = Guid.NewGuid().ToString();

            var nugetCache = Environment.GetEnvironmentVariable("UserProfile") + @"\.nuget\packages\";
            var assyRefs = new List<MetadataReference>()
            {
                //  assumed present in output artifact directory (aka bin/Debug|Release/...)
                MetadataReference.CreateFromFile(Path.Join(Directory.GetCurrentDirectory(), "MarkLogic.Client.dll"))
            };

            // TODO: this is NOT portable because of hardcoded version numbers
            assyRefs.AddRange(Directory.GetFiles(Path.Join(nugetCache, @"netstandard.library\2.0.3\build\netstandard2.0\ref"), "*.dll").Select(fp => MetadataReference.CreateFromFile(fp)));
            assyRefs.AddRange(Directory.GetFiles(Path.Join(nugetCache, @"newtonsoft.json\12.0.1\lib\netstandard2.0"), "*.dll").Select(fp => MetadataReference.CreateFromFile(fp)));

            var compileOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithAssemblyIdentityComparer(DesktopAssemblyIdentityComparer.Default)
                .WithOptimizationLevel(OptimizationLevel.Debug);
            var compilation = CSharpCompilation.Create(assyName, new[] { syntaxTree }, assyRefs, compileOptions);

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

        [Theory]
        [InlineData("../../../../../src/main/ml-modules/root/test")]
        [InlineData("../../../../../src/main/ml-modules/root/test/atomics")]
        [InlineData("../../../../../src/main/ml-modules/root/test/complex")]
        public async void TestGenerateService(string pathToService)
        {
            using (var codeWriter = new StringWriter())
            {
                await Code.GenerateService(pathToService, codeWriter, new CodeGeneratorCSharp());
                var sourceCode = codeWriter.ToString();
                Output.WriteLine(sourceCode);

                var assy = BuildAssembly(sourceCode, Output);

                Assert.NotNull(assy);
            }
        }

        [Fact]
        public void TestGenerateServiceAllTypes()
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
                var codeGen = new CodeGeneratorCSharp();
                codeGen.GenerateService(service, endpoints.ToArray(), codeWriter);
                var sourceCode = codeWriter.ToString();
                Output.WriteLine(sourceCode);

                var assy = BuildAssembly(sourceCode, Output);

                Assert.NotNull(assy);
            }
        }

        private static Endpoint CreateEndpoint(string funcName, string dataType, string netClass, bool isMultipleParams = false, bool isMultiple = false, bool isNullable = false, bool hasSession = false, bool nullableSession = false)
        {
            var endpoint = new Endpoint() { FunctionName = funcName };

            var paramCount = isMultipleParams ? 2 : 1;
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
    }
}