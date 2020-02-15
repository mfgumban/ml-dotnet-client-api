using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfMultipartForMultipart/".
    /// </summary>
    public partial class PostOfMultipartForMultipart : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfMultipartForMultipart object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfMultipartForMultipart(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfMultipartForMultipart/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfMultipartForMultipart object.</returns>
        public static PostOfMultipartForMultipart Create(IDatabaseClient dbClient)
        {
            return new PostOfMultipartForMultipart(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartJsonDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartJsonDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartJsonDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartBinaryDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartBinaryDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartBinaryDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartXmlDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartXmlDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartXmlDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartBinaryDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartBinaryDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartBinaryDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartBinaryDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartBinaryDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartBinaryDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartXmlDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartXmlDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartXmlDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartXmlDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartXmlDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartXmlDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartJsonDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartJsonDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartJsonDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartJsonDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartJsonDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartJsonDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartTextDocument1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartTextDocument1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartTextDocument1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartTextDocument0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartTextDocument0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartTextDocument0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartArray1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartArray1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartArray1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartArray1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartArray1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartArray1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartArray0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartArray0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartArray0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForMultipartTextDocument1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfMultipartForMultipartTextDocument1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForMultipartTextDocument1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }
    }
}
