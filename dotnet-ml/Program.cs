using MarkLogic.Client.Tools.Actions;
using MarkLogic.Client.Tools.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IConsole>(new CLIConsole())
                    .AddSingleton<IFilesystem>(new Filesystem())
                    .BuildServiceProvider();

                var actionRoot = new CompositeActionBuilder()
                    .WithAction(ScaffoldAction.Default)
                    .Create();

                var host = new ActionHost(actionRoot, serviceProvider);
                return host.Run(args).GetAwaiter().GetResult();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error ({e.GetType().Name}): {e.Message}\nStack Trace: {e.StackTrace}");
                return -1;
            }
        }
    }
}
