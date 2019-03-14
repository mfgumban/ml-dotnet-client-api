using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EndpointDescriptor
    {
        public EndpointDescriptor()
        {
            Parameters = new List<ParameterDescriptor>();
        }

        [JsonProperty("functionName")]
        public string FunctionName { get; set; }

        public string ModuleName => $"{FunctionName}.xqy";

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("params")]
        public IList<ParameterDescriptor> Parameters { get; private set; }

        [JsonProperty("return")]
        public ReturnDescriptor ReturnValue { get; set; }

        [JsonIgnore]
        public bool ReturnVoid => ReturnValue == null;

        [JsonProperty("errorDetail")]
        public string ErrorDetail { get; set; }

        public ParameterDescriptor Session => Parameters.FirstOrDefault(p => p.IsSession);

        public IEnumerable<ParameterDescriptor> ParametersNoSession => Session == null ? Parameters : Parameters.Except(new[] { Session });

        public bool HasSession => Session != null;

        public static async Task<EndpointDescriptor> FromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();
                return FromString(content);
            }
        }

        public static EndpointDescriptor FromString(string json)
        {
            return JsonConvert.DeserializeObject<EndpointDescriptor>(json);
        }
    }
}
