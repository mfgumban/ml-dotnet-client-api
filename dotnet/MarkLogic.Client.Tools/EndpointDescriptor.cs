using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools
{
    public enum ModuleType
    {
        SJS,
        XQuery
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class EndpointDescriptor
    {
        public EndpointDescriptor()
        {
            Parameters = new List<ParameterDescriptor>();
        }

        [JsonProperty("functionName")]
        public string FunctionName { get; set; }

        public ModuleType ModuleType { get; set; }

        public string ModuleName => $"{FunctionName}.{(ModuleType == ModuleType.SJS ? "sjs" : "xqy")}";

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

        public static async Task<EndpointDescriptor> FromStreamAsync(Stream stream, ModuleType moduleType)
        {
            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();
                return FromString(content, moduleType);
            }
        }

        public static EndpointDescriptor FromString(string json, ModuleType moduleType)
        {
            var desc = JsonConvert.DeserializeObject<EndpointDescriptor>(json);
            desc.ModuleType = moduleType;
            return desc;
        }
    }
}
