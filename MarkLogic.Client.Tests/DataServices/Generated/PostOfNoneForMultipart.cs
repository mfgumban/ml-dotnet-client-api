using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfNoneForMultipart/".
    /// </summary>
    public partial class PostOfNoneForMultipart : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfNoneForMultipart object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfNoneForMultipart(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfNoneForMultipart/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfNoneForMultipart object.</returns>
        public static PostOfNoneForMultipart Create(IDatabaseClient dbClient)
        {
            return new PostOfNoneForMultipart(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartXmlDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartXmlDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForMultipartXmlDocument1ReturnNull.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartJsonDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartJsonDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForMultipartJsonDocument1ReturnNull.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartArray1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartArray1()
        {
            return CreateRequest("postOfNoneForMultipartArray1.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartArray0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartArray0()
        {
            return CreateRequest("postOfNoneForMultipartArray0.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartBinaryDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartBinaryDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForMultipartBinaryDocument1ReturnNull.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartJsonDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartJsonDocument1()
        {
            return CreateRequest("postOfNoneForMultipartJsonDocument1.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartJsonDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartJsonDocument0()
        {
            return CreateRequest("postOfNoneForMultipartJsonDocument0.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartTextDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartTextDocument1()
        {
            return CreateRequest("postOfNoneForMultipartTextDocument1.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartArray1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartArray1ReturnNull()
        {
            return CreateRequest("postOfNoneForMultipartArray1ReturnNull.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartTextDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartTextDocument0()
        {
            return CreateRequest("postOfNoneForMultipartTextDocument0.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartXmlDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartXmlDocument0()
        {
            return CreateRequest("postOfNoneForMultipartXmlDocument0.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartXmlDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartXmlDocument1()
        {
            return CreateRequest("postOfNoneForMultipartXmlDocument1.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartBinaryDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartBinaryDocument1()
        {
            return CreateRequest("postOfNoneForMultipartBinaryDocument1.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartBinaryDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartBinaryDocument0()
        {
            return CreateRequest("postOfNoneForMultipartBinaryDocument0.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForMultipartTextDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfNoneForMultipartTextDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForMultipartTextDocument1ReturnNull.xqy")
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }
    }
}
