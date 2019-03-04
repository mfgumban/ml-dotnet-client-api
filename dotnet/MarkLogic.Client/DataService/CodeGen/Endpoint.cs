using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.DataService.CodeGen
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Endpoint
    {
        public Endpoint()
        {
            Parameters = new List<Parameter>();
        }

        [JsonProperty("functionName")]
        public string FunctionName { get; set; }

        [JsonIgnore]
        public string ModuleName => $"{FunctionName}.xqy";

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("params")]
        public IList<Parameter> Parameters { get; private set; }

        [JsonProperty("return")]
        public Return ReturnValue { get; set; }

        [JsonProperty("errorDetail")]
        public string ErrorDetail { get; set; }

        [JsonIgnore]
        public bool RequireSession { get; }

        public static async Task<Endpoint> FromStreamAsync(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var content = await reader.ReadToEndAsync();
                return FromString(content);
            }
        }

        public static Endpoint FromString(string json)
        {
            return JsonConvert.DeserializeObject<Endpoint>(json);
        }
    }
}
