namespace MarkLogic.Client.Tools
{
    public interface ITypeDescriptor
    {
        string DataType { get; }

        bool Nullable { get; }

        bool Multiple { get; }

        string NetClass { get; }
    }
}
