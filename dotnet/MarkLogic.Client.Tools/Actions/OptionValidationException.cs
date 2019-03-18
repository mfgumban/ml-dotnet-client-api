using System;

namespace MarkLogic.Client.Tools.Actions
{
    public class OptionValidationException : Exception
    {
        public OptionValidationException(string verb, string optName, string message)
            : base($"Option [{optName}] for action [{verb}]: {message}")
        {
            Verb = verb;
            Option = optName;
        }

        public string Verb { get; }

        public string Option { get; }
    }
}
