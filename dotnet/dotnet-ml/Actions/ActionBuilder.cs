using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI.Actions
{
    public sealed class ActionBuilder
    {
        private class Action : IAction
        {
            public string Verb { get; set; }

            public List<Option> OptionsList { get; } = new List<Option>();

            public Func<IServiceProvider, Task<int>> ExecuteFunc { get; set; }

            public IEnumerable<IAction> SubActions => new IAction[0];

            public IEnumerable<Option> Options => OptionsList;
            
            public bool HasOptions => OptionsList.Count > 0;

            public Task<int> Execute(IServiceProvider serviceProvider)
            {
                return ExecuteFunc(serviceProvider);
            }
        }

        private Action _action;

        public ActionBuilder(string verb)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(verb), "Action verb cannot be null, empty, or whitespace");
            _action = new Action() { Verb = verb };
        }

        public IAction Create()
        {
            return _action;
        }

        public ActionBuilder WithOption(string name, string shorthand = null, int minArgs = 0, int maxArgs = 0)
        {
            var option = new Option(name, shorthand, minArgs, maxArgs);
            Debug.Assert(!_action.OptionsList.Any(o => o.Name.EqualsIgnoreCase(option.Name)), $"Action already has an existing option named {option.Name}");
            if (option.HasShorthand)
            {
                Debug.Assert(_action.OptionsList.Any(o => o.Shorthand.EqualsIgnoreCase(option.Shorthand)), $"Action already has an existing option with shorthand of {option.Shorthand}");
            }
            _action.OptionsList.Add(option);
            return this;
        }

        public ActionBuilder OnExecute(Func<IServiceProvider, Task<int>> executeFunc)
        {
            Debug.Assert(executeFunc != null, "executeFunc cannot be null");
            _action.ExecuteFunc = executeFunc;
            return this;
        }
    }
}
