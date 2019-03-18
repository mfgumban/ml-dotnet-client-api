using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public sealed class SimpleActionBuilder
    {
        private class SimpleAction : IAction
        {
            public string Verb { get; set; }

            public Func<IServiceProvider, Task<int>> ExecuteFunc { get; set; }

            public Task<int> Execute(IServiceProvider serviceProvider, IEnumerable<string> args)
            {
                return ExecuteFunc(serviceProvider);
            }
        }

        private SimpleAction _action;

        public SimpleActionBuilder()
        {
            _action = new SimpleAction();
        }

        public IAction Create()
        {
            return _action;
        }

        public SimpleActionBuilder WithVerb(string verb)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(verb), "Action verb cannot be null, empty, or whitespace");
            _action.Verb = verb;
            return this;
        }

        public SimpleActionBuilder OnExecute(Func<IServiceProvider, Task<int>> executeFunc)
        {
            Debug.Assert(executeFunc != null, "executeFunc cannot be null");
            _action.ExecuteFunc = executeFunc;
            return this;
        }
    }
}
