using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfMultipartForDocument/".
    /// </summary>
    public partial class PostOfMultipartForDocument : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfMultipartForDocument object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfMultipartForDocument(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfMultipartForDocument/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfMultipartForDocument object.</returns>
        public static PostOfMultipartForDocument Create(IDatabaseClient dbClient)
        {
            return new PostOfMultipartForDocument(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentTextDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentTextDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentTextDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentXmlDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentXmlDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentXmlDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentTextDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentTextDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentTextDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentTextDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentTextDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentTextDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentXmlDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentXmlDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentXmlDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentBinaryDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentBinaryDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentBinaryDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentJsonDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentJsonDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentJsonDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentJsonDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentJsonDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentJsonDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentArray1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentArray1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentArray1.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentXmlDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentXmlDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentXmlDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentArray0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentArray0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentArray0.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentBinaryDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentBinaryDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentBinaryDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentBinaryDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentBinaryDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentBinaryDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentObject1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentObject1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentObject1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentObject0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentObject0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentObject0.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentObject1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentObject1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentObject1.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentJsonDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentJsonDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentJsonDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForDocumentArray1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<Stream> PostOfMultipartForDocumentArray1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForDocumentArray1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestSingle<Stream>(false, Unmarshal.Stream);
        }
    }
}
