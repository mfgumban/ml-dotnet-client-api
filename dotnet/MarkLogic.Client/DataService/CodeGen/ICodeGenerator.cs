using System.IO;

namespace MarkLogic.Client.DataService.CodeGen
{
    public interface ICodeGenerator
    {
        void GenerateService(Service serviceDecl, Endpoint[] endpointDecl, TextWriter output);
    }
}
