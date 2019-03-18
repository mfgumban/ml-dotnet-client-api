using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public sealed class CompositeActionBuilder
    {
        private class CompositeAction : IAction
        {
            public string Verb { get; set; }

            public List<IAction> SubActionList { get; } = new List<IAction>();

            public Task<int> Execute(IServiceProvider serviceProvider, IEnumerable<string> args)
            {
                var subVerb = args.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(subVerb))
                {
                    throw new ActionNotFoundException();
                }
                var subAction = SubActionList.FirstOrDefault(a => a.Verb == subVerb);
                if (subAction == null)
                {
                    throw new ActionNotFoundException(subVerb);
                }
                return subAction.Execute(serviceProvider, args.Skip(1));
            }
        }

        private CompositeAction _action;

        public CompositeActionBuilder()
        {
            _action = new CompositeAction();
        }

        public IAction Create()
        {
            return _action;
        }

        public CompositeActionBuilder WithVerb(string verb)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(verb), "Action verb cannot be null, empty, or whitespace");
            _action.Verb = verb;
            return this;
        }

        public CompositeActionBuilder WithAction(IAction action)
        {
            Debug.Assert(action != null, "Action cannot be null");
            Debug.Assert(!_action.SubActionList.Any(a => a.Verb.EqualsIgnoreCase(action.Verb)), $"Composite action already has a sub action with the verb {action.Verb}");
            _action.SubActionList.Add(action);
            return this;
        }
    }
}
