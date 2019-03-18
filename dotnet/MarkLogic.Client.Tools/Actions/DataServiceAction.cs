using MarkLogic.Client.Tools.CodeGen.CSharp;
using MarkLogic.Client.Tools.Services;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public static class DataServiceAction
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
            .WithOption("input", shorthand: "i", minArgs: 1, maxArgs: 1, deserialize: (args, optSet) => optSet.ServiceFilePath = args.FirstOrDefault())
            .WithOption("output", shorthand: "o", minArgs: 1, maxArgs: 1, deserialize: (args, optSet) => optSet.OutputPath = args.FirstOrDefault())
            .OnCreateExecContext(() => new ExecContext())
            .OnExecute(async (serviceProvider, opts) =>
            {
                var fs = serviceProvider.GetService<IFilesystem>();

                var sdp = await ServiceDescriptorProvider.Load(opts.ServiceFilePath, fs);
                if (!fs.PathExists(opts.OutputPath))
                {
                    throw new ActionException(Verb, $"Output path not found: {opts.OutputPath}");
                }

                var outputFilePath = Path.Combine(opts.OutputPath, sdp.Service.ClassName + ".cs");
                using (var writer = new StreamWriter(fs.OpenWrite(outputFilePath)))
                {
                    await CodeGenerator.DataServiceClass(sdp, writer);
                }

                var toolConfigFilePath = Path.Combine(fs.CurrentDirectory, ProjectToolConfig.DefaultFilename);
                var toolConfig = fs.PathExists(toolConfigFilePath) ? await ProjectToolConfig.Load(toolConfigFilePath, fs) : new ProjectToolConfig();
                toolConfig.AddDataService(new ProjectToolConfig.DataServiceConfig());
                await toolConfig.Save(toolConfigFilePath, fs);

                return 0;
            })
            .Create());
    }
}
