using MarkLogic.Client.DataService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests
{
    public interface IPartService
    {
        Task<IEnumerable<string>> listParts(int pageLength, IEnumerable<string> options, TextReader doc);
    }

    public class PartService : DataServiceBase, IPartService
    {
        protected PartService(IDatabaseClient dbClient) : base(dbClient, "/inventory/part/")
        {
        }

        public static PartService Create(IDatabaseClient dbClient)
        {
            return new PartService(dbClient);
        }

        public Task<IEnumerable<string>> listParts(int pageLength, IEnumerable<string> options, TextReader doc)
        {
            return CreateRequest("listParts.xqy")
                .WithParameters(
                    new SingleParameter<int>("pageLength", true, pageLength, Marshal.Integer),
                    new MultipleParameter<string>("options", true, options, Marshal.String),
                    new SingleParameter<TextReader>("doc", true, doc, Marshal.TextReaderAsXML))
                .RequestMultiple<string>(true, Unmarshal.String);
        }
    }
}
