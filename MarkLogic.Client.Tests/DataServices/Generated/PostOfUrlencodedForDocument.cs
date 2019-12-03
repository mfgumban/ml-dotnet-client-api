using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfUrlencodedForDocument/".
    /// </summary>
    public partial class PostOfUrlencodedForDocument : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfUrlencodedForDocument object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfUrlencodedForDocument(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfUrlencodedForDocument/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfUrlencodedForDocument object.</returns>
        public static PostOfUrlencodedForDocument Create(IDatabaseClient dbClient)
        {
            return new PostOfUrlencodedForDocument(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentObject1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentObject1ReturnNull(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentObject1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentArray1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentArray1ReturnNull(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentArray1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentBinaryDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentBinaryDocument1ReturnNull(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentBinaryDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentTextDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentTextDocument1ReturnNull(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentTextDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentArray1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentArray1(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentArray1.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentArray0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentArray0(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentArray0.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentXmlDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentXmlDocument1(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentXmlDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentXmlDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentXmlDocument0(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentXmlDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentXmlDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentXmlDocument1ReturnNull(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentXmlDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentJsonDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentJsonDocument0(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentJsonDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentJsonDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentJsonDocument1(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentJsonDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentObject0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentObject0(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentObject0.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentTextDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentTextDocument0(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentTextDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentTextDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentTextDocument1(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentTextDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentObject1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentObject1(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentObject1.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentBinaryDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentBinaryDocument0(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentBinaryDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentBinaryDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentBinaryDocument1(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentBinaryDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForDocumentJsonDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfUrlencodedForDocumentJsonDocument1ReturnNull(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedForDocumentJsonDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }
    }
}
