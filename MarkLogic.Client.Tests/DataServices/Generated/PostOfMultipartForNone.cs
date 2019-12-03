using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfMultipartForNone/".
    /// </summary>
    public partial class PostOfMultipartForNone : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfMultipartForNone object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfMultipartForNone(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfMultipartForNone/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfMultipartForNone object.</returns>
        public static PostOfMultipartForNone Create(IDatabaseClient dbClient)
        {
            return new PostOfMultipartForNone(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartObjectForNone1(Stream param1, double param2, float param3)
        {
            return CreateRequest("postOfMultipartObjectForNone1.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson), 
                    new SingleParameter<double>("param2", false, param2, Marshal.Double), 
                    new SingleParameter<float>("param3", false, param3, Marshal.Float))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartObjectForNone0(Stream param1)
        {
            return CreateRequest("postOfMultipartObjectForNone0.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone2.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartObjectForNone2(Stream param1)
        {
            return CreateRequest("postOfMultipartObjectForNone2.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone3.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartObjectForNone3(Stream param1, double param2, float param3)
        {
            return CreateRequest("postOfMultipartObjectForNone3.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<double>("param2", false, param2, Marshal.Double), 
                    new SingleParameter<float>("param3", false, param3, Marshal.Float))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone7.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartObjectForNone7(Stream param1, double param2, float param3)
        {
            return CreateRequest("postOfMultipartObjectForNone7.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<double>("param2", false, param2, Marshal.Double), 
                    new SingleParameter<float>("param3", false, param3, Marshal.Float))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone6.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartObjectForNone6(Stream param1)
        {
            return CreateRequest("postOfMultipartObjectForNone6.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone4.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartObjectForNone4(Stream param1)
        {
            return CreateRequest("postOfMultipartObjectForNone4.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartObjectForNone5.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartObjectForNone5(Stream param1, double param2, float param3)
        {
            return CreateRequest("postOfMultipartObjectForNone5.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson), 
                    new SingleParameter<double>("param2", false, param2, Marshal.Double), 
                    new SingleParameter<float>("param3", false, param3, Marshal.Float))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone7.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartTextDocumentForNone7(IEnumerable<Stream> param1, long param2, uint param3)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone7.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsText), 
                    new SingleParameter<long>("param2", false, param2, Marshal.Long), 
                    new SingleParameter<uint>("param3", false, param3, Marshal.UnsignedInteger))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone6.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartTextDocumentForNone6(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone6.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsText))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone4.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartTextDocumentForNone4(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone4.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone5.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartTextDocumentForNone5(IEnumerable<Stream> param1, long param2, uint param3)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone5.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsText), 
                    new SingleParameter<long>("param2", false, param2, Marshal.Long), 
                    new SingleParameter<uint>("param3", false, param3, Marshal.UnsignedInteger))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartTextDocumentForNone1(Stream param1, long param2, uint param3)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone1.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsText), 
                    new SingleParameter<long>("param2", false, param2, Marshal.Long), 
                    new SingleParameter<uint>("param3", false, param3, Marshal.UnsignedInteger))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartTextDocumentForNone0(Stream param1)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone0.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsText))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone2.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartTextDocumentForNone2(Stream param1)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone2.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsText))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartTextDocumentForNone3.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartTextDocumentForNone3(Stream param1, long param2, uint param3)
        {
            return CreateRequest("postOfMultipartTextDocumentForNone3.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsText), 
                    new SingleParameter<long>("param2", false, param2, Marshal.Long), 
                    new SingleParameter<uint>("param3", false, param3, Marshal.UnsignedInteger))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone7.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartJsonDocumentForNone7(IEnumerable<Stream> param1, int param2, long param3)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone7.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<int>("param2", false, param2, Marshal.Integer), 
                    new SingleParameter<long>("param3", false, param3, Marshal.Long))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartArrayForNone1(Stream param1, bool param2, double param3)
        {
            return CreateRequest("postOfMultipartArrayForNone1.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson), 
                    new SingleParameter<bool>("param2", false, param2, Marshal.Boolean), 
                    new SingleParameter<double>("param3", false, param3, Marshal.Double))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone7.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartXmlDocumentForNone7(IEnumerable<Stream> param1, uint param2, ulong param3)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone7.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsXml), 
                    new SingleParameter<uint>("param2", false, param2, Marshal.UnsignedInteger), 
                    new SingleParameter<ulong>("param3", false, param3, Marshal.UnsignedLong))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone6.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartXmlDocumentForNone6(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone6.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsXml))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartArrayForNone0(Stream param1)
        {
            return CreateRequest("postOfMultipartArrayForNone0.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartAllForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <param name="param5"></param>
        /// <param name="param6"></param>
        public Task PostOfMultipartAllForNone0(IEnumerable<Stream> param1, Stream param2, Stream param3, IEnumerable<Stream> param4, Stream param5, Stream param6)
        {
            return CreateRequest("postOfMultipartAllForNone0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<Stream>("param2", false, param2, Marshal.StreamAsJson), 
                    new SingleParameter<Stream>("param3", true, param3, Marshal.StreamAsBinary), 
                    new MultipleParameter<Stream>("param4", false, param4, Marshal.StreamAsJson), 
                    new SingleParameter<Stream>("param5", true, param5, Marshal.StreamAsText), 
                    new SingleParameter<Stream>("param6", false, param6, Marshal.StreamAsXml))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone6.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartJsonDocumentForNone6(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone6.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone4.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartJsonDocumentForNone4(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone4.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone2.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartArrayForNone2(Stream param1)
        {
            return CreateRequest("postOfMultipartArrayForNone2.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone4.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartXmlDocumentForNone4(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone4.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsXml))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone5.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartXmlDocumentForNone5(IEnumerable<Stream> param1, uint param2, ulong param3)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone5.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsXml), 
                    new SingleParameter<uint>("param2", false, param2, Marshal.UnsignedInteger), 
                    new SingleParameter<ulong>("param3", false, param3, Marshal.UnsignedLong))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone3.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartArrayForNone3(Stream param1, bool param2, double param3)
        {
            return CreateRequest("postOfMultipartArrayForNone3.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<bool>("param2", false, param2, Marshal.Boolean), 
                    new SingleParameter<double>("param3", false, param3, Marshal.Double))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone5.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartJsonDocumentForNone5(IEnumerable<Stream> param1, int param2, long param3)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone5.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson), 
                    new SingleParameter<int>("param2", false, param2, Marshal.Integer), 
                    new SingleParameter<long>("param3", false, param3, Marshal.Long))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartJsonDocumentForNone1(Stream param1, int param2, long param3)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone1.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson), 
                    new SingleParameter<int>("param2", false, param2, Marshal.Integer), 
                    new SingleParameter<long>("param3", false, param3, Marshal.Long))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartXmlDocumentForNone1(Stream param1, uint param2, ulong param3)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone1.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsXml), 
                    new SingleParameter<uint>("param2", false, param2, Marshal.UnsignedInteger), 
                    new SingleParameter<ulong>("param3", false, param3, Marshal.UnsignedLong))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone7.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartArrayForNone7(IEnumerable<Stream> param1, bool param2, double param3)
        {
            return CreateRequest("postOfMultipartArrayForNone7.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<bool>("param2", false, param2, Marshal.Boolean), 
                    new SingleParameter<double>("param3", false, param3, Marshal.Double))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone6.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartArrayForNone6(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartArrayForNone6.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartXmlDocumentForNone0(Stream param1)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone0.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsXml))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartJsonDocumentForNone0(Stream param1)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone0.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone2.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartJsonDocumentForNone2(Stream param1)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone2.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone2.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartXmlDocumentForNone2(Stream param1)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone2.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsXml))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone4.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartArrayForNone4(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartArrayForNone4.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartArrayForNone5.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartArrayForNone5(IEnumerable<Stream> param1, bool param2, double param3)
        {
            return CreateRequest("postOfMultipartArrayForNone5.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsJson), 
                    new SingleParameter<bool>("param2", false, param2, Marshal.Boolean), 
                    new SingleParameter<double>("param3", false, param3, Marshal.Double))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartXmlDocumentForNone3.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartXmlDocumentForNone3(Stream param1, uint param2, ulong param3)
        {
            return CreateRequest("postOfMultipartXmlDocumentForNone3.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsXml), 
                    new SingleParameter<uint>("param2", false, param2, Marshal.UnsignedInteger), 
                    new SingleParameter<ulong>("param3", false, param3, Marshal.UnsignedLong))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartJsonDocumentForNone3.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartJsonDocumentForNone3(Stream param1, int param2, long param3)
        {
            return CreateRequest("postOfMultipartJsonDocumentForNone3.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsJson), 
                    new SingleParameter<int>("param2", false, param2, Marshal.Integer), 
                    new SingleParameter<long>("param3", false, param3, Marshal.Long))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone4.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartBinaryDocumentForNone4(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone4.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone5.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartBinaryDocumentForNone5(IEnumerable<Stream> param1, float param2, int param3)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone5.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary), 
                    new SingleParameter<float>("param2", false, param2, Marshal.Float), 
                    new SingleParameter<int>("param3", false, param3, Marshal.Integer))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone7.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartBinaryDocumentForNone7(IEnumerable<Stream> param1, float param2, int param3)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone7.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsBinary), 
                    new SingleParameter<float>("param2", false, param2, Marshal.Float), 
                    new SingleParameter<int>("param3", false, param3, Marshal.Integer))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone6.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartBinaryDocumentForNone6(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone6.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", true, param1, Marshal.StreamAsBinary))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone2.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartBinaryDocumentForNone2(Stream param1)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone2.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsBinary))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone3.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartBinaryDocumentForNone3(Stream param1, float param2, int param3)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone3.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", true, param1, Marshal.StreamAsBinary), 
                    new SingleParameter<float>("param2", false, param2, Marshal.Float), 
                    new SingleParameter<int>("param3", false, param3, Marshal.Integer))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        public Task PostOfMultipartBinaryDocumentForNone1(Stream param1, float param2, int param3)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone1.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary), 
                    new SingleParameter<float>("param2", false, param2, Marshal.Float), 
                    new SingleParameter<int>("param3", false, param3, Marshal.Integer))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfMultipartBinaryDocumentForNone0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfMultipartBinaryDocumentForNone0(Stream param1)
        {
            return CreateRequest("postOfMultipartBinaryDocumentForNone0.xqy")
                .WithParameters(
                    new SingleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestNone();
        }
    }
}
