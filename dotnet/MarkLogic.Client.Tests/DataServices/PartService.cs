using MarkLogic.Client.DataService;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class PartService : DataServiceBase
    {
        protected PartService(IDatabaseClient dbClient) : base(dbClient, "/inventory/part/")
        {
        }

        public static PartService Create(IDatabaseClient dbClient)
        {
            return new PartService(dbClient);
        }

        public Task<IEnumerable<string>> listParts(int pageLength, IEnumerable<string> options, Stream doc)
        {
            return CreateRequest("listParts.xqy")
                .WithParameters(
                    new SingleParameter<int>("pageLength", true, pageLength, Marshal.Integer),
                    new MultipleParameter<string>("options", true, options, Marshal.String),
                    new SingleParameter<Stream>("doc", true, doc, Marshal.StreamAsXml))
                .RequestMultiple<string>(true, Unmarshal.String);
        }
    }
}
