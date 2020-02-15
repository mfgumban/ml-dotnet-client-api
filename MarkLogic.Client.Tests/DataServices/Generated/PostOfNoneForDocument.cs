using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfNoneForDocument/".
    /// </summary>
    public partial class PostOfNoneForDocument : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfNoneForDocument object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfNoneForDocument(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfNoneForDocument/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfNoneForDocument object.</returns>
        public static PostOfNoneForDocument Create(IDatabaseClient dbClient)
        {
            return new PostOfNoneForDocument(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentTextDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentTextDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForDocumentTextDocument1ReturnNull.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentObject1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentObject1ReturnNull()
        {
            return CreateRequest("postOfNoneForDocumentObject1ReturnNull.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentArray1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentArray1ReturnNull()
        {
            return CreateRequest("postOfNoneForDocumentArray1ReturnNull.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentBinaryDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentBinaryDocument1()
        {
            return CreateRequest("postOfNoneForDocumentBinaryDocument1.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentObject0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentObject0()
        {
            return CreateRequest("postOfNoneForDocumentObject0.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentObject1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentObject1()
        {
            return CreateRequest("postOfNoneForDocumentObject1.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentBinaryDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentBinaryDocument0()
        {
            return CreateRequest("postOfNoneForDocumentBinaryDocument0.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentJsonDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentJsonDocument1()
        {
            return CreateRequest("postOfNoneForDocumentJsonDocument1.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentJsonDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentJsonDocument0()
        {
            return CreateRequest("postOfNoneForDocumentJsonDocument0.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentArray1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentArray1()
        {
            return CreateRequest("postOfNoneForDocumentArray1.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentArray0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentArray0()
        {
            return CreateRequest("postOfNoneForDocumentArray0.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentBinaryDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentBinaryDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForDocumentBinaryDocument1ReturnNull.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentTextDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentTextDocument1()
        {
            return CreateRequest("postOfNoneForDocumentTextDocument1.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentXmlDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentXmlDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForDocumentXmlDocument1ReturnNull.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentTextDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentTextDocument0()
        {
            return CreateRequest("postOfNoneForDocumentTextDocument0.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentXmlDocument1.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentXmlDocument1()
        {
            return CreateRequest("postOfNoneForDocumentXmlDocument1.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentXmlDocument0.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentXmlDocument0()
        {
            return CreateRequest("postOfNoneForDocumentXmlDocument0.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfNoneForDocumentJsonDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<Stream> PostOfNoneForDocumentJsonDocument1ReturnNull()
        {
            return CreateRequest("postOfNoneForDocumentJsonDocument1ReturnNull.xqy")
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }
    }
}
