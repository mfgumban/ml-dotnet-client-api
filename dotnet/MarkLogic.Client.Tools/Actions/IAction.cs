using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public interface IAction
    {
        string Verb { get; }

        IEnumerable<IAction> SubActions { get; }

        IEnumerable<IOption> Options { get; }

        bool HasOptions { get; }

        Task<int> Execute(IServiceProvider serviceProvider, IEnumerable<string> args);
    }
}
