namespace MarkLogic.Client.Tools.Actions
{
    public interface IOption
    {
        string Name { get; }

        string Shorthand { get; }

        bool HasShorthand { get; }

        int MaxArgs { get; }

        int MinArgs { get; }
    }
}