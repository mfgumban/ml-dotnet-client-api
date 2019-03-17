using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI
{
    public sealed class ActionHost
    {
        public ActionHost(IAction root, IServiceProvider serviceProvider)
        {
            Root = root;
            ServiceProvider = serviceProvider;
        }

        public IAction Root { get; }

        public IServiceProvider ServiceProvider { get; }

        public int Run(string[] args)
        {
            foreach(var arg in args)
            {
                Console.WriteLine($"arg: {arg}");
            }


            Console.ReadKey();
            return 0;
        }
    }
}
