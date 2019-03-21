using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MarkLogic.Client.Tools
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ParameterDescriptor : ITypeDescriptor
    {
        private string _argName = null;

        [JsonProperty("name")]
        public string Name { get; set; }

        public string ArgumentName
        {
            get
            {
                var result = Regex.Replace(Name, @"[^A-Za-z0-9]+", "_");
                if (result.Length > 0 && !(char.IsLetter(result, 0) || result[0] == '_'))
                {
                    result = "_" + result;
                }
                return result;
            }
        }

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
