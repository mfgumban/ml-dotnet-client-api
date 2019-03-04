using MarkLogic.Client.DataService;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    /// <summary>
    /// Service description.
    /// </summary>
    public class PartService : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PartService object.
        /// </summary>
        /// <param name="dbClient">Client connection to a MarkLogic server.</param>
        protected PartService(IDatabaseClient dbClient) : base(dbClient, "/inventory/part/")
        {
        }

        /// <summary>
        /// Constructs a new PartService object. 
        /// </summary>
        /// <param name="dbClient">Client connection to a MarkLogic server.</param>
        /// <returns>A new PartService object.</returns>
        public static PartService Create(IDatabaseClient dbClient)
        {
            return new PartService(dbClient);
        }

        /// <summary>
        /// Endpoint description.
        /// </summary>
        /// <param name="pageLength">Parameter description.</param>
        /// <param name="options">Parameter description.</param>
        /// <param name="doc">Parameter description.</param>
        /// <returns>Return value description.</returns>
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
