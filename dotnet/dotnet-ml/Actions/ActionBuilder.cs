using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI.Actions
{
    public sealed class ActionBuilder<TOptionSet> where TOptionSet : class
    {
        private class Action : IAction
        {
            public string Verb { get; set; }

            public IEnumerable<IAction> SubActions => new IAction[0];

            public List<Option> OptionsList { get; } = new List<Option>();

            public IEnumerable<Option> Options => OptionsList;

            public bool HasOptions => OptionsList.Count > 0;

            public Func<TOptionSet> CreateOptionSetFunc { get; set; }

            public Func<IServiceProvider, TOptionSet, Task<int>> ExecuteFunc { get; set; }

            public Task<int> Execute(IServiceProvider serviceProvider, string[] options)
            {
                var opts = CreateOptionSetFunc != null ? CreateOptionSetFunc() : null;
                if (opts != null)
                {

                }
                return ExecuteFunc(serviceProvider, opts);
            }
        }

        private Action _action;

        public ActionBuilder()
        {
            _action = new Action();
        }

        public IAction Create()
        {
            return _action;
        }

        public ActionBuilder<TOptionSet> WithVerb(string verb)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(verb), "Action verb cannot be null, empty, or whitespace");
            _action.Verb = verb;
            return this;
        }

        public ActionBuilder<TOptionSet> OnCreateOptionSet(Func<TOptionSet> createFunc)
        {
            Debug.Assert(createFunc != null, "executeFunc cannot be null");
            _action.CreateOptionSetFunc = createFunc;
            return this;
        }

        public ActionBuilder<TOptionSet> WithOption(string name, string shorthand = null, int minArgs = 0, int maxArgs = 0, Action<string, TOptionSet> deserialize = null)
        {
            var option = new Option(name, shorthand, minArgs, maxArgs);
            Debug.Assert(!_action.OptionsList.Any(o => o.Name.EqualsIgnoreCase(option.Name)), $"Action already has an existing option named {option.Name}");
            if (option.HasShorthand)
            {
                Debug.Assert(!_action.OptionsList.Any(o => o.Shorthand.EqualsIgnoreCase(option.Shorthand)), $"Action already has an existing option with shorthand of {option.Shorthand}");
            }
            _action.OptionsList.Add(option);
            return this;
        }

        public ActionBuilder<TOptionSet> OnExecute(Func<IServiceProvider, TOptionSet, Task<int>> executeFunc)
        {
            Debug.Assert(executeFunc != null, "executeFunc cannot be null");
            _action.ExecuteFunc = executeFunc;
            return this;
        }
    }
}
