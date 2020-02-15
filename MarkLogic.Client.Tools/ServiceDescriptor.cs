using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ServiceDescriptor
    {
        [JsonProperty("endpointDirectory")]
        public string EndpointDirectory { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("$javaClass")]
        public string JavaClass { get; set; }

        [JsonProperty("$netClass")]
        public string NetClass { get; set; }

        public string ClassFullName => string.IsNullOrWhiteSpace(NetClass) ? JavaClass : NetClass;

        public bool HasClassFullName => !string.IsNullOrWhiteSpace(ClassFullName);

        public string[] ClassFullNameTokens => ClassFullName.Split('.');

        public string ClassName => ClassFullNameTokens.LastOrDefault();

        public string[] NamespaceTokens => ClassFullNameTokens.Length == 1 ? new string[0] : ClassFullNameTokens.Take(ClassFullNameTokens.Length - 1).ToArray();

        public string Namespace => string.Join(".", NamespaceTokens);

        public bool HasNamespace => NamespaceTokens != null && NamespaceTokens.Length >= 1;

        public static async Task<ServiceDescriptor> FromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();
                return FromString(content);
            }
        }

        public static ServiceDescriptor FromString(string json)
        {
            return JsonConvert.DeserializeObject<ServiceDescriptor>(json);
        }
    }
}
