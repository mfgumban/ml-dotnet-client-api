using MarkLogic.Client.Tools.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tools
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class ProjectToolConfig
    {
        public const string DefaultFilename = "ml-config.json";

        [JsonObject(MemberSerialization.OptIn)]
        public sealed class DataServiceConfig
        {
            [JsonProperty("input")]
            public string Input { get; set; }

            [JsonProperty("output")]
            public string Output { get; set; }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (!(obj is DataServiceConfig))
                {
                    return false;
                }
                var ds = (DataServiceConfig)obj;
                return Input == ds.Input && Output == ds.Output;
            }
        }

        private readonly List<DataServiceConfig> _dataServices = new List<DataServiceConfig>();

        public ProjectToolConfig()
        {
        }

        [JsonProperty("dataservices")]
        public IList<DataServiceConfig> DataServices => _dataServices;

        public void AddDataService(DataServiceConfig dsConfig)
        {
            if (!DataServices.Any(ds => ds.Equals(dsConfig)))
            {
                DataServices.Add(dsConfig);
            }
        }

        public static async Task<ProjectToolConfig> Load(string path, IFilesystem fs)
        {
            using (var reader = new StreamReader(fs.OpenRead(path)))
            {
                var content = await reader.ReadToEndAsync();
                if (string.IsNullOrWhiteSpace(content))
                {
                    content = "{}";
                }
                return JsonConvert.DeserializeObject<ProjectToolConfig>(content);
            }
        }

        public Task Save(string path, IFilesystem fs)
        {
            using (var writer = new StreamWriter(fs.OpenWrite(path)))
            {
                var content = JsonConvert.SerializeObject(this);
                return writer.WriteAsync(content);
            }
        }
    }
}
