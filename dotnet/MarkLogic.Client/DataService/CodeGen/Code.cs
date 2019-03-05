using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.DataService.CodeGen
{
    public class Code
    {
        public static async Task GenerateService(string serviceFilePath, TextWriter output, ICodeGenerator codeGen)
        {
            var fsService = File.OpenRead(Path.Combine(serviceFilePath, "service.json"));
            var serviceDecl = await Service.FromStreamAsync(fsService);
            fsService.Dispose();

            var endpointDecls = new List<Endpoint>();
            foreach(var apiFilePath in Directory.EnumerateFiles(serviceFilePath, "*.api", SearchOption.TopDirectoryOnly))
            {
                var fsEndpoint = File.OpenRead(apiFilePath);
                endpointDecls.Add(await Endpoint.FromStreamAsync(fsEndpoint));
                fsEndpoint.Dispose();
            }

            codeGen.GenerateService(serviceDecl, endpointDecls.ToArray(), output);
        }
    }
}
