using Newtonsoft.Json;

namespace MarkLogic.Client.Tools
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ParameterDescriptor : ITypeDescriptor
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

        [JsonProperty("$netClass")]
        public string NetClass { get; set; }

        public bool IsSession => DataType.EqualsIgnoreCase("session");
    }
}
