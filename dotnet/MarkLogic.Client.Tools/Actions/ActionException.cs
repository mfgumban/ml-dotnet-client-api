using System;

namespace MarkLogic.Client.Tools.Actions
{
    public class ActionException : Exception
    {
        public ActionException(string verb, string message)
            : base(message)
        {
            Verb = verb;
        }

        public string Verb { get; }
    }
}
