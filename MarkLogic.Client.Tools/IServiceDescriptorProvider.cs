using System.Collections.Generic;

namespace MarkLogic.Client.Tools
{
    public interface IServiceDescriptorProvider
    {
        ServiceDescriptor Service { get; }

        IEnumerable<EndpointDescriptor> Endpoints { get; }
    }
}