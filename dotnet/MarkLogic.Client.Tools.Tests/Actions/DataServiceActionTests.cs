using MarkLogic.Client.Tools.Actions;
using MarkLogic.Client.Tools.Services;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MarkLogic.Client.Tools.Tests.Actions
{
    public class DataServiceActionTests
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

        //[Theory]
        //[InlineData(new[] { "--input", "ml-modules/root/ds", "--output", "DataServices" }, true)]
        public async void ActionOptions(string[] testArgs)
        {
            var fs = new MockFilesystem();
            
            // very forgiving mock; only focused in properly supplying data
            fs.OnPathExists = (path) => true;
            fs.OnEnumerateFiles = (path, searchPattern) => new[] { "ml-modules/root/ds/TestEndpoint.api" };
            fs.OnOpenFile = (path, readOnly) =>
            {
                switch(path)
                {
                    case "ml-modules/root/ds/service.json":
                    case "ml-modules/root/ds/TestEndpoint.api":
                    default:
                        throw new FileNotFoundException();
                }
            };

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsole, MockConsole>()
                .AddSingleton<IFilesystem>(fs)
                .BuildServiceProvider();

            var action = DataServiceAction.Default;
            var retVal = await action.Execute(serviceProvider, testArgs);

            
        }
    }
}
