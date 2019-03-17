using System.Diagnostics;

namespace MarkLogic.Client.Tools.Actions
{
    public class Option : IOption
    {
        public Option(string name, string shorthand, int minArgs, int maxArgs)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name), "Option name cannot be null, empty, or whitespace");
            Name = name;
            Shorthand = shorthand;
            Debug.Assert(minArgs <= maxArgs, "minArgs must be less than or equal to maxArgs");
            Debug.Assert(minArgs >= 0, "minArgs cannot be negative");
            Debug.Assert(maxArgs >= 0, "maxArgs cannot be negative");
            MinArgs = minArgs;
            MaxArgs = maxArgs;
        }

        public string Name { get; }

        public string Shorthand { get; }

        public bool HasShorthand => !string.IsNullOrWhiteSpace(Shorthand);

        public int MinArgs { get; }

        public int MaxArgs { get; }
    }
}
