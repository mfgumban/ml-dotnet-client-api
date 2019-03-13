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
            assyRefs.AddRange(Directory.GetFiles(Path.Join(nugetCache, @"netstandard.library\2.0.3\build\netstandard2.0\ref"), "*.dll").Select(fp => MetadataReference.CreateFromFile(fp)));

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
            var output = new StringWriter();
            await Code.GenerateService(pathToService, output, new CodeGeneratorCSharp());
            var sourceCode = output.ToString();
            Output.WriteLine(sourceCode);

            var assy = BuildAssembly(sourceCode, Output);

            Assert.NotNull(assy);
        }
    }
}