using MarkLogic.Client.Tools.CodeGen.CSharp;
using MarkLogic.Client.Tools.Services;
using System.IO;
using System.Linq;

namespace MarkLogic.Client.Tools.Actions
{
    public static class ScaffoldDataServiceAction
    {
        public sealed class ExecContext
        {
            public string ServiceFilePath { get; set; }

            public string OutputPath { get; set; }
        }

        private static IAction _action;

        public const string Verb = "dataservice";

        public static IAction Default => _action ?? (_action = new ActionBuilder<ExecContext>()
            .WithVerb(Verb)
            .WithOption("input", shorthand: "i", required: false, minArgs: 1, maxArgs: 1, deserialize: (args, optSet) => optSet.ServiceFilePath = args.FirstOrDefault())
            .WithOption("output", shorthand: "o", required: false, minArgs: 1, maxArgs: 1, deserialize: (args, optSet) => optSet.OutputPath = args.FirstOrDefault())
            .OnCreateExecContext(() => new ExecContext())
            .OnExecute(async (serviceProvider, execContext) =>
            {
                var console = serviceProvider.GetService<IConsole>();
                var fs = serviceProvider.GetService<IFilesystem>();

                var serviceFilePath = Path.GetFullPath(execContext.ServiceFilePath ?? fs.CurrentDirectory);
                var outputPath = Path.GetFullPath(execContext.OutputPath ?? fs.CurrentDirectory);

                // read service.json
                var sdp = await ServiceDescriptorProvider.Load(serviceFilePath, fs);
                console.WriteLine($"Read {serviceFilePath}.");
                console.WriteLine($"Found {sdp.Endpoints.Count()} endpoints.");

                // validate
                if (!sdp.Service.HasClassFullName)
                {
                    throw new ActionException(Verb, $"Unable to determine full class name.  The service.json file may not have a $netClass or $javaClass property.");
                }
                if (!sdp.Service.HasNamespace)
                {
                    throw new ActionException(Verb, $"Unable to determine namespace.  $netClass should contain a fully qualified class name, which includes the namespace");
                }

                // generate output code file
                if (!fs.PathExists(outputPath))
                {
                    throw new ActionException(Verb, $"Output path not found: {outputPath}");
                }
                var outputFilePath = Path.Combine(outputPath, sdp.Service.ClassName + ".cs");
                using (var writer = new StreamWriter(fs.OpenWrite(outputFilePath)))
                {
                    await CodeGenerator.DataServiceClass(sdp, writer);
                }
                console.WriteLine($"Generated data service class at {outputFilePath}.");

                // persist scaffold configuration
                var toolConfigFilePath = Path.Combine(fs.CurrentDirectory, ProjectToolConfig.DefaultFilename);
                var toolConfig = fs.PathExists(toolConfigFilePath) ? await ProjectToolConfig.Load(toolConfigFilePath, fs) : new ProjectToolConfig();
                toolConfig.AddDataService(new ProjectToolConfig.DataServiceConfig()
                {
                    Input = execContext.ServiceFilePath ?? "./",
                    Output = execContext.OutputPath ?? "./"
                });
                await toolConfig.Save(toolConfigFilePath, fs);
                console.WriteLine($"Updated {toolConfigFilePath}.");

                // TODO: modify project file to include scaffolding during build

                return 0;
            })
            .Create());
    }
}
