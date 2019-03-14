using MarkLogic.Client.DataService.CodeGen;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public partial class DescriptorTests
    {
        public DescriptorTests(ITestOutputHelper output)
        {
            Output = output;
        }

        private ITestOutputHelper Output { get; }

        public const string ValidServiceDescriptor = @"
        {
          ""endpointDirectory"": ""/path/to/endpoints/"",
          ""$javaClass"": ""com.mynamespace.MyJavaService"",
          ""$netClass"": ""MyNamespace.MyNetService"",
          ""desc"": ""Service description.""
        }";

        public const string ValidServiceDescriptorNoNs = @"
        {
          ""endpointDirectory"": ""/path/to/endpoints/"",
          ""$netClass"": ""MyService"",
          ""desc"": ""Service description.""
        }";

        public static IEnumerable<object[]> ServiceDescriptorData()
        {
            return new[]
            {
                new object[] { ValidServiceDescriptor, "/path/to/endpoints/", "MyNetService", "MyNamespace", new[] { "MyNamespace" } },
                new object[] { ValidServiceDescriptorNoNs, "/path/to/endpoints/", "MyService", "", new string[0] },
            };
        }

        [Theory]
        [MemberData(nameof(ServiceDescriptorData))]
        public void ServiceFromString(string serviceJson, string expectedDir, string expectedClassName, string expectedNamespce, string[] expectedNsTokens)
        {
            var service = Service.FromString(serviceJson);
            Assert.NotNull(service);
            Assert.Equal(expectedDir, service.EndpointDirectory);
            Assert.Equal(expectedClassName, service.ClassName);
            Assert.Equal(expectedNamespce, service.Namespace);
            Assert.Equal(expectedNsTokens, service.NamespaceTokens);
        }
    }
}
