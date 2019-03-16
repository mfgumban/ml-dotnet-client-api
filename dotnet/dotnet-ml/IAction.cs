using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI
{
    public interface IAction
    {
        string Verb { get; }

        IEnumerable<IAction> SubActions { get; }

        IEnumerable<Option> Options { get; }

        bool HasOptions { get; }

        Task<int> Execute(IServiceProvider serviceProvider);
    }
}
