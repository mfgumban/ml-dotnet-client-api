using MarkLogic.NetCoreCLI.Actions;
using MarkLogic.NetCoreCLI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarkLogic.NetCoreCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsole>(new CLIConsole())
                .BuildServiceProvider();

            var actionRoot = new CompositeActionBuilder()
                .WithAction(ScaffoldAction.Default)
                .Create();

            var host = new ActionHost(actionRoot, serviceProvider);
            host.Run(args);
        }
    }
}
