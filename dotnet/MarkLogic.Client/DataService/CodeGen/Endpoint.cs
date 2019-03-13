using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public string ModuleName => $"{FunctionName}.xqy";

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("params")]
        public IList<Parameter> Parameters { get; private set; }

        [JsonProperty("return")]
        public Return ReturnValue { get; set; }

        [JsonIgnore]
        public bool ReturnVoid => ReturnValue == null;

        [JsonProperty("errorDetail")]
        public string ErrorDetail { get; set; }

        public Parameter Session => Parameters.FirstOrDefault(p => p.IsSession);

        public IEnumerable<Parameter> ParametersNoSession => Session == null ? Parameters : Parameters.Except(new[] { Session });

        public bool HasSession => Session != null;

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
