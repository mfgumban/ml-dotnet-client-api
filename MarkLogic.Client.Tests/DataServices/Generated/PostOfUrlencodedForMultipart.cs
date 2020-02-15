using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfUrlencodedForMultipart/".
    /// </summary>
    public partial class PostOfUrlencodedForMultipart : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfUrlencodedForMultipart object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfUrlencodedForMultipart(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfUrlencodedForMultipart/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfUrlencodedForMultipart object.</returns>
        public static PostOfUrlencodedForMultipart Create(IDatabaseClient dbClient)
        {
            return new PostOfUrlencodedForMultipart(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartJsonDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartJsonDocument1ReturnNull(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartJsonDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartXmlDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartXmlDocument1ReturnNull(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartXmlDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartArray1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartArray1ReturnNull(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartArray1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartXmlDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartXmlDocument1(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartXmlDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartXmlDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartXmlDocument0(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartXmlDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartBinaryDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartBinaryDocument1ReturnNull(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartBinaryDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartTextDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartTextDocument0(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartTextDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartTextDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartTextDocument1(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartTextDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartJsonDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartJsonDocument0(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartJsonDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartJsonDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartJsonDocument1(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartJsonDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartBinaryDocument0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartBinaryDocument0(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartBinaryDocument0.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartBinaryDocument1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartBinaryDocument1(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartBinaryDocument1.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartTextDocument1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartTextDocument1ReturnNull(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartTextDocument1ReturnNull.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartArray1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartArray1(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartArray1.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForMultipartArray0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<IEnumerable<Stream>> PostOfUrlencodedForMultipartArray0(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedForMultipartArray0.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestMultiple<Stream>(true, Unmarshal.Stream);
        }
    }
}
