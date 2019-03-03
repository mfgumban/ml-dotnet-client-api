using Newtonsoft.Json;

namespace MarkLogic.Client.DataService.CodeGen
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Parameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("datatype")]
        public string DataType { get; set; }

        [JsonProperty("nullable")]
        public bool Nullable { get; set; }

        [JsonProperty("multiple")]
        public bool Multiple { get; set; }
    }
}
