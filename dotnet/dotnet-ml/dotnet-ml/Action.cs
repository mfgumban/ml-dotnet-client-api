using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MarkLogic.NetCoreCLI
{
    public abstract class Action
    {
        protected Action(string verb, IEnumerable<Argument> arguments)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(verb), "Action verb cannot be null, empty, or whitespace");
            Verb = verb;

            if (arguments != null)
            {
                var argCnt = arguments.Count();
                var nameCnt = arguments.Select(a => a.Name).Distinct().Count();
                var shorthandCnt = arguments.Select(a => a.Shorthand).Distinct().Count();
                Debug.Assert(nameCnt == argCnt, "One or more arguments may have the same name.");
                Debug.Assert(shorthandCnt == argCnt, "One or more arguments may have the same shorthand.");
                Arguments = arguments.ToArray();
                HasArguments = argCnt > 0;
            }
            else
            {
                Arguments = new Argument[0];
                HasArguments = false;
            }
        }

        public string Verb { get; }

        public IEnumerable<Argument> Arguments { get; }

        public bool HasArguments { get; }
    }
}
