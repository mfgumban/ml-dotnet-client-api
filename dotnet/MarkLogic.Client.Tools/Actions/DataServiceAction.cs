using MarkLogic.Client.Tools.CodeGen.CSharp;
using MarkLogic.Client.Tools.Services;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public static class DataServiceAction
    {
        public sealed class OptionSet
        {
            public string ServiceFilePath { get; set; }

            public string OutputFilePath { get; set; }
        }

        private static IAction _action;

        public static IAction Default => _action ?? (_action = new ActionBuilder<OptionSet>()
            .WithVerb("dataservice")
            .WithOption("service", shorthand: "s", minArgs: 1, maxArgs: 1, deserialize: (args, optSet) => optSet.ServiceFilePath = args.FirstOrDefault())
            .WithOption("output", shorthand: "o", minArgs: 1, maxArgs: 1, deserialize: (args, optSet) => optSet.OutputFilePath = args.FirstOrDefault())
            .OnCreateOptionSet(() => new OptionSet())
            .OnExecute(async (serviceProvider, opts) =>
            {
                var fs = serviceProvider.GetService<IFilesystem>();
                var sdp = await ServiceDescriptorProvider.Load(opts.ServiceFilePath, fs);
                //var outputFilePath = Path.Combine(fs.CurrentDirectory, sdp.Service.ClassName + ".cs");
                var outputFilePath = opts.OutputFilePath;
                using (var writer = new StreamWriter(fs.OpenWrite(outputFilePath)))
                {
                    await CodeGenerator.DataServiceClass(sdp, writer);
                }
                return 0;
            })
            .Create());
    }
}
