using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.Actions
{
    public sealed class ActionBuilder<TExecContext> where TExecContext : class
    {
        private class Option
        {
            public Option(string name, string shorthand, bool required, int minArgs, int maxArgs, Action<IEnumerable<string>, TExecContext> deserialize)
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(name), "Option name cannot be null, empty, or whitespace");
                Name = name;
                Shorthand = shorthand;
                Required = required;
                Debug.Assert(minArgs <= maxArgs, "minArgs must be less than or equal to maxArgs");
                Debug.Assert(minArgs >= 0, "minArgs cannot be negative");
                Debug.Assert(maxArgs >= 0, "maxArgs cannot be negative");
                MinArgs = minArgs;
                MaxArgs = maxArgs;
                DeserializeFunc = deserialize;
            }

            public bool IsMatch(string arg)
            {
                var optName = arg.TrimStart('-');
                return arg.StartsWith("--") ? optName == Name : (arg.StartsWith("-") && HasShorthand ? optName == Shorthand : false);
            }

            public string Name { get; set; }

            public string Shorthand { get; set; }

            public bool HasShorthand => !string.IsNullOrWhiteSpace(Shorthand);

            public bool Required { get; set; }

            public int MinArgs { get; set; }

            public int MaxArgs { get; set; }

            public Action<IEnumerable<string>, TExecContext> DeserializeFunc { get; }
        }

        private class Action : IAction
        {
            public string Verb { get; set; }

            public List<Option> OptionsList { get; } = new List<Option>();

            public bool HasOptions => OptionsList.Count > 0;

            public Func<TExecContext> CreateExecContextFunc { get; set; }

            public Func<IServiceProvider, TExecContext, Task<int>> ExecuteFunc { get; set; }

            public Task<int> Execute(IServiceProvider serviceProvider, IEnumerable<string> args)
            {
                var execContext = CreateExecContextFunc != null ? CreateExecContextFunc() : null;
                var usedOpts = new List<Option>();
                if (HasOptions && execContext != null)
                {
                    Option currentOpt = null;
                    var currentOptArgs = new List<string>();
                    var deserializeAction = new Action<Option>((newOpt) =>
                    {
                        if (currentOptArgs.Count < currentOpt.MinArgs || currentOptArgs.Count > currentOpt.MaxArgs)
                        {
                            throw new OptionValidationException(Verb, currentOpt.Name, $"Invalid number of arguments; expected [{currentOpt.MinArgs},{currentOpt.MaxArgs}] but found {currentOptArgs.Count}");
                        }
                        currentOpt.DeserializeFunc(currentOptArgs, execContext);
                        currentOptArgs.Clear();
                        usedOpts.Add(currentOpt);
                        currentOpt = newOpt;
                    });

                    foreach(var arg in args)
                    {
                        var opt = OptionsList.FirstOrDefault(o => o.IsMatch(arg));
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

                foreach(var requiredOpt in OptionsList.Where(o => o.Required))
                {
                    if (!usedOpts.Any(uo => uo == requiredOpt))
                    {
                        throw new OptionValidationException(Verb, requiredOpt.Name, $"Option is required");
                    }
                }

                return ExecuteFunc(serviceProvider, execContext);
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

        public ActionBuilder<TExecContext> WithVerb(string verb)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(verb), "Action verb cannot be null, empty, or whitespace");
            _action.Verb = verb;
            return this;
        }

        public ActionBuilder<TExecContext> OnCreateExecContext(Func<TExecContext> createFunc)
        {
            Debug.Assert(createFunc != null, "createFunc cannot be null");
            _action.CreateExecContextFunc = createFunc;
            return this;
        }

        public ActionBuilder<TExecContext> WithOption(string name, string shorthand = null, bool required = false, int minArgs = 0, int maxArgs = 0, Action<IEnumerable<string>, TExecContext> deserialize = null)
        {
            var option = new Option(name, shorthand, required, minArgs, maxArgs, deserialize);
            Debug.Assert(!_action.OptionsList.Any(o => o.Name.EqualsIgnoreCase(option.Name)), $"Action already has an existing option named {option.Name}");
            if (option.HasShorthand)
            {
                Debug.Assert(!_action.OptionsList.Any(o => o.Shorthand.EqualsIgnoreCase(option.Shorthand)), $"Action already has an existing option with shorthand of {option.Shorthand}");
            }
            _action.OptionsList.Add(option);
            return this;
        }

        public ActionBuilder<TExecContext> OnExecute(Func<IServiceProvider, TExecContext, Task<int>> executeFunc)
        {
            Debug.Assert(executeFunc != null, "executeFunc cannot be null");
            _action.ExecuteFunc = executeFunc;
            return this;
        }
    }
}
