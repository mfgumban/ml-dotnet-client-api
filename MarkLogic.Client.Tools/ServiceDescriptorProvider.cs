using MarkLogic.Client.Tools.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools
{
    public class ServiceDescriptorProvider : IServiceDescriptorProvider
    {
        private ServiceDescriptorProvider(ServiceDescriptor service, IEnumerable<EndpointDescriptor> endpoints)
        {
            Service = service;
            Endpoints = endpoints.ToArray();
        }

        public ServiceDescriptor Service { get; }

        public IEnumerable<EndpointDescriptor> Endpoints { get; }

        public static async Task<IServiceDescriptorProvider> Load(string serviceFilePath, IFilesystem fs)
        {
            var serviceStrean = fs.OpenRead(serviceFilePath);
            var serviceDesc = await ServiceDescriptor.FromStreamAsync(serviceStrean);
            serviceStrean.Dispose();

            var endpointDescs = new List<EndpointDescriptor>();
            foreach (var apiFilePath in fs.EnumerateFiles(Path.GetDirectoryName(serviceFilePath), "*.api"))
            {
                var modulePath = Path.ChangeExtension(apiFilePath, "sjs");
                var moduleType = fs.PathExists(modulePath) ? ModuleType.SJS : ModuleType.XQuery;
                var fsEndpoint = fs.OpenRead(apiFilePath);
                endpointDescs.Add(await EndpointDescriptor.FromStreamAsync(fsEndpoint, moduleType));
                fsEndpoint.Dispose();
            }

            return new ServiceDescriptorProvider(serviceDesc, endpointDescs);
        }
    }
}
