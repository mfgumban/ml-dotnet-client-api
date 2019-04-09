using MarkLogic.Client.Tools.Actions;
using MarkLogic.Client.Tools.Services;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using Xunit;

namespace MarkLogic.Client.Tools.Tests.Actions
{
    public class ScaffoldDataServiceTests
    {
        public const string ServiceDescriptor = @"
        {
            ""endpointDirectory"": ""/path/in/marklogic/"",
            ""$netClass"": ""TestNs.TestService""
        }";

        public const string EndpointDescriptor = @"
        {
            ""functionName"": ""TestEndpoint""
        }";

        [Theory]
        [InlineData(new[] { "--input", "ml-modules/root/ds/service.json", "--output", "DataServices" }, 0)]
        [InlineData(new[] { "-i", "ml-modules/root/ds/service.json", "-o", "DataServices" }, 0)]
        public async void NormalOptions(string[] testArgs, int expectedRetVal)
        {
            var fs = new MockFilesystem();
            var codeFilePath = Path.GetTempFileName();
            var mlConfigFilePath = Path.GetTempFileName();

            // very forgiving; only focused in properly supplying data
            fs.CurrentDirectory = "/";
            fs.OnPathExists = (path) => true;
            fs.OnEnumerateFiles = (path, searchPattern) => new[] { "ml-modules/root/ds/TestEndpoint.api" };
            fs.OnOpenFile = (path, readOnly) =>
            {
                switch(Path.GetFileName(path))
                {
                    case "service.json": return ServiceDescriptor.ToStream();
                    case "TestEndpoint.api": return EndpointDescriptor.ToStream();
                    case "TestService.cs": return File.Open(codeFilePath, FileMode.OpenOrCreate, readOnly ? FileAccess.Read : FileAccess.ReadWrite, FileShare.None);
                    case "ml-config.json": return File.Open(mlConfigFilePath, FileMode.OpenOrCreate, readOnly ? FileAccess.Read : FileAccess.ReadWrite, FileShare.None);
                    default: throw new FileNotFoundException($"File {path} not found.", path);
                }
            };

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsole, MockConsole>()
                .AddSingleton<IFilesystem>(fs)
                .BuildServiceProvider();

            var action = ScaffoldDataServiceAction.Default;
            var retVal = await action.Execute(serviceProvider, testArgs);

            Assert.Equal(expectedRetVal, retVal);

            // validate generated code
            using (var codeFileReader = new StreamReader(codeFilePath))
            { 
                var content = await codeFileReader.ReadToEndAsync();
                Assert.True(content.Length > 0);
            }

            // validate ml-config.json
            var mlConfig = await ProjectToolConfig.Load(mlConfigFilePath, new Filesystem());
            Assert.Single(mlConfig.DataServices);
            Assert.EndsWith("ml-modules/root/ds/service.json", mlConfig.DataServices.First().Input);
            Assert.EndsWith("DataServices", mlConfig.DataServices.First().Output);

            File.Delete(codeFilePath);
            File.Delete(mlConfigFilePath);
        }
    }
}
