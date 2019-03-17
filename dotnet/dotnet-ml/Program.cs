using MarkLogic.Client.Tools.Actions;
using MarkLogic.Client.Tools.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarkLogic.NetCoreCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
            catch(Exception e)
            {
                Console.WriteLine($"Error ({e.GetType().Name}): {e.Message}");
            }
        }
    }
}
