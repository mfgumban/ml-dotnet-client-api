using System;

namespace MarkLogic.Client.Tools.Actions
{
    public class ActionNotFoundException : Exception
    {
        public ActionNotFoundException()
            : base($"No action specified")
        {
        }

        public ActionNotFoundException(string verb)
            : base($"Unrecognized action [{verb}]")
        {
            Verb = verb;
        }

        public string Verb { get; }
    }
}
