using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public sealed class ActionBuilder<TOptionSet> where TOptionSet : class
    {
        private class Option : Actions.Option
        {
            public Option(string name, string shorthand, int minArgs, int maxArgs, Action<IEnumerable<string>, TOptionSet> deserialize)
                :base(name, shorthand, minArgs, maxArgs)
            {
                DeserializeFunc = deserialize;
            }

            public bool IsMatch(string arg)
            {
                var optName = arg.TrimStart('-');
                return arg.StartsWith("--") ? optName == Name : (arg.StartsWith("-") && HasShorthand ? optName == Shorthand : false);
            }

            public Action<IEnumerable<string>, TOptionSet> DeserializeFunc { get; }
        }

        private class Action : IAction
        {
            public string Verb { get; set; }

            public IEnumerable<IAction> SubActions => new IAction[0];

            public List<IOption> OptionsList { get; } = new List<IOption>();

            public IEnumerable<IOption> Options => OptionsList;

            public bool HasOptions => OptionsList.Count > 0;

            public Func<TOptionSet> CreateOptionSetFunc { get; set; }

            public Func<IServiceProvider, TOptionSet, Task<int>> ExecuteFunc { get; set; }

            public Task<int> Execute(IServiceProvider serviceProvider, IEnumerable<string> args)
            {
                var optSet = CreateOptionSetFunc != null ? CreateOptionSetFunc() : null;
                Debug.Assert(HasOptions && optSet != null, $"Action {Verb} has options but did not instantiate an options set container.");
                if (optSet != null)
                {
                    Option currentOpt = null;
                    List<string> currentOptArgs = new List<string>();
                    var deserializeAction = new Action<Option>((newOpt) =>
                    {
                        if (currentOptArgs.Count < currentOpt.MinArgs || currentOptArgs.Count > currentOpt.MaxArgs)
                        {
                            throw new ActionException(Verb, $"Invalid number of arguments for option {currentOpt.Name}; expected [{currentOpt.MinArgs},{currentOpt.MaxArgs}] but recieved {currentOptArgs.Count}.");
                        }
                        currentOpt.DeserializeFunc(currentOptArgs, optSet);
                        currentOptArgs.Clear();
                        currentOpt = newOpt;
                    });

                    foreach(var arg in args)
                    {
                        var opt = Options.Cast<Option>().FirstOrDefault(o => o.IsMatch(arg));
                        if (opt != null && currentOpt != null)
                        {
                            deserializeAction(opt);
                        }
                        else if (opt != null)
                        {
                            currentOpt = opt;
                        }
                        else
                        {
                            currentOptArgs.Add(arg);
                        }
                    }

                    if (currentOpt != null)
                    {
                        deserializeAction(null);
                    }
                }
                return ExecuteFunc(serviceProvider, optSet);
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

        public ActionBuilder<TOptionSet> WithOption(string name, string shorthand = null, int minArgs = 0, int maxArgs = 0, Action<IEnumerable<string>, TOptionSet> deserialize = null)
        {
            var option = new Option(name, shorthand, minArgs, maxArgs, deserialize);
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
