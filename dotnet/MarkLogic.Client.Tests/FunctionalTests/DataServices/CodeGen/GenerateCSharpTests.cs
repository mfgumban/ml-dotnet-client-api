using MarkLogic.Client.DataService.CodeGen;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests.DataServices.CodeGen
{
    public class GenerateCSharpTests
    {
        public GenerateCSharpTests(ITestOutputHelper output)
        {
            Output = output;
        }

        private ITestOutputHelper Output { get; }

        [Fact]
        public async void TestGenerateService()
        {
            var output = new StringWriter();
            await Code.GenerateService("../../../../../src/main/ml-modules/root/test", output, new CodeGeneratorCSharp());
            var src = output.ToString();
            Output.WriteLine(src);
        }
    }
}