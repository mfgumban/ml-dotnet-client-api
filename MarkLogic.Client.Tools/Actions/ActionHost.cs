using System;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
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

        public Task<int> Run(string[] args)
        {
            return Root.Execute(ServiceProvider, args);
        }
    }
}
