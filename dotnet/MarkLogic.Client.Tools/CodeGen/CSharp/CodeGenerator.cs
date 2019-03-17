using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.CodeGen.CSharp
{
    public class CodeGenerator
    {
        public static async Task DataServiceClass(string serviceFilePath, TextWriter output)
        {
            var fsService = File.OpenRead(Path.Combine(serviceFilePath, "service.json"));
            var serviceDesc = await ServiceDescriptor.FromStreamAsync(fsService);
            fsService.Dispose();

            var endpointDescs = new List<EndpointDescriptor>();
            foreach(var apiFilePath in Directory.EnumerateFiles(serviceFilePath, "*.api", SearchOption.TopDirectoryOnly))
            {
                var fsEndpoint = File.OpenRead(apiFilePath);
                endpointDescs.Add(await EndpointDescriptor.FromStreamAsync(fsEndpoint));
                fsEndpoint.Dispose();
            }

            await DataServiceClass(serviceDesc, endpointDescs, output);
        }

        public static async Task DataServiceClass(ServiceDescriptor serviceDesc, IEnumerable<EndpointDescriptor> endpointDescs, TextWriter output)
        {
            var writer = new IndentedTextWriter(output);
            var generator = new DataServiceGenerator(serviceDesc, endpointDescs);
            await Task.Run(() => generator.WriteTo(new IndentedTextWriter(output)));
        }
    }
}
