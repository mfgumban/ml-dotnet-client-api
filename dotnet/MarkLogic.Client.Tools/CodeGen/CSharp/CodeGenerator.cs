using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools.CodeGen.CSharp
{
    public class CodeGenerator
    {
        public static Task DataServiceClass(IServiceDescriptorProvider provider, TextWriter output)
        {
            return DataServiceClass(provider.Service, provider.Endpoints, output);
        }

        public static Task DataServiceClass(ServiceDescriptor serviceDesc, IEnumerable<EndpointDescriptor> endpointDescs, TextWriter output)
        {
            var writer = new IndentedTextWriter(output);
            var generator = new DataServiceGenerator(serviceDesc, endpointDescs);
            return Task.Run(() => generator.WriteTo(new IndentedTextWriter(output)));
        }
    }
}
