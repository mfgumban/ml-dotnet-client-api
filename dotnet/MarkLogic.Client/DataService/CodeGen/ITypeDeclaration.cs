namespace MarkLogic.Client.DataService.CodeGen
{
    public interface ITypeDeclaration
    {
        string DataType { get; }

        bool Nullable { get; }

        bool Multiple { get; }

        string NetClass { get; }
    }
}
