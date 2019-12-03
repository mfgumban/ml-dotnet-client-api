using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfMultipartForText/".
    /// </summary>
    public partial class PostOfMultipartForText : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfMultipartForText object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfMultipartForText(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfMultipartForText/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfMultipartForText object.</returns>
        public static PostOfMultipartForText Create(IDatabaseClient dbClient)
        {
            return new PostOfMultipartForText(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextUnsignedInt1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<uint?> PostOfMultipartForTextUnsignedInt1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextUnsignedInt1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<uint?>(false, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextString1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<string> PostOfMultipartForTextString1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextString1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextUnsignedLong1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<ulong?> PostOfMultipartForTextUnsignedLong1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextUnsignedLong1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<ulong?>(false, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextString0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<string> PostOfMultipartForTextString0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextString0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDate0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime> PostOfMultipartForTextDate0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDate0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime>(false, Unmarshal.Date);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDate1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfMultipartForTextDate1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDate1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Date));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextUnsignedInt1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<uint?> PostOfMultipartForTextUnsignedInt1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextUnsignedInt1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<uint?>(false, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextFloat1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<float?> PostOfMultipartForTextFloat1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextFloat1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<float?>(false, Unmarshal.Nullable(Unmarshal.Float));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextUnsignedInt0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<uint> PostOfMultipartForTextUnsignedInt0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextUnsignedInt0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<uint>(false, Unmarshal.UnsignedInteger);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextBoolean0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<bool> PostOfMultipartForTextBoolean0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextBoolean0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<bool>(false, Unmarshal.Boolean);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextTime1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfMultipartForTextTime1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextTime1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Time));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextBoolean1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<bool?> PostOfMultipartForTextBoolean1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextBoolean1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<bool?>(false, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextLong1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<long?> PostOfMultipartForTextLong1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextLong1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<long?>(false, Unmarshal.Nullable(Unmarshal.Long));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDecimal1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<decimal?> PostOfMultipartForTextDecimal1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDecimal1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<decimal?>(false, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextString1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<string> PostOfMultipartForTextString1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextString1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextInt1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<int?> PostOfMultipartForTextInt1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextInt1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<int?>(false, Unmarshal.Nullable(Unmarshal.Integer));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextInt0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<int> PostOfMultipartForTextInt0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextInt0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<int>(false, Unmarshal.Integer);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextInt1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<int?> PostOfMultipartForTextInt1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextInt1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<int?>(false, Unmarshal.Nullable(Unmarshal.Integer));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextUnsignedLong0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<ulong> PostOfMultipartForTextUnsignedLong0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextUnsignedLong0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<ulong>(false, Unmarshal.UnsignedLong);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextUnsignedLong1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<ulong?> PostOfMultipartForTextUnsignedLong1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextUnsignedLong1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<ulong?>(false, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDouble1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<double?> PostOfMultipartForTextDouble1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDouble1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<double?>(false, Unmarshal.Nullable(Unmarshal.Double));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDayTimeDuration1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<TimeSpan?> PostOfMultipartForTextDayTimeDuration1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDayTimeDuration1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<TimeSpan?>(false, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextTime1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfMultipartForTextTime1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextTime1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Time));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextLong1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<long?> PostOfMultipartForTextLong1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextLong1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<long?>(false, Unmarshal.Nullable(Unmarshal.Long));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextLong0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<long> PostOfMultipartForTextLong0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextLong0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<long>(false, Unmarshal.Long);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextTime0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime> PostOfMultipartForTextTime0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextTime0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime>(false, Unmarshal.Time);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDateTime1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfMultipartForTextDateTime1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDateTime1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.DateTime));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextBoolean1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<bool?> PostOfMultipartForTextBoolean1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextBoolean1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<bool?>(false, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDecimal1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<decimal?> PostOfMultipartForTextDecimal1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDecimal1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<decimal?>(false, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDecimal0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<decimal> PostOfMultipartForTextDecimal0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDecimal0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<decimal>(false, Unmarshal.Decimal);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDateTime0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime> PostOfMultipartForTextDateTime0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDateTime0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime>(false, Unmarshal.DateTime);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDateTime1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfMultipartForTextDateTime1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDateTime1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.DateTime));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextFloat1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<float?> PostOfMultipartForTextFloat1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextFloat1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<float?>(false, Unmarshal.Nullable(Unmarshal.Float));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextFloat0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<float> PostOfMultipartForTextFloat0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextFloat0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<float>(false, Unmarshal.Float);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDouble1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<double?> PostOfMultipartForTextDouble1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDouble1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<double?>(false, Unmarshal.Nullable(Unmarshal.Double));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDate1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfMultipartForTextDate1ReturnNull(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDate1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Date));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDouble0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<double> PostOfMultipartForTextDouble0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDouble0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<double>(false, Unmarshal.Double);
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDayTimeDuration1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<TimeSpan?> PostOfMultipartForTextDayTimeDuration1(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDayTimeDuration1.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<TimeSpan?>(false, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }

        /// <summary>
        /// Invokes the "postOfMultipartForTextDayTimeDuration0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<TimeSpan> PostOfMultipartForTextDayTimeDuration0(IEnumerable<Stream> param1)
        {
            return CreateRequest("postOfMultipartForTextDayTimeDuration0.xqy")
                .WithParameters(
                    new MultipleParameter<Stream>("param1", false, param1, Marshal.StreamAsBinary))
                .RequestSingle<TimeSpan>(false, Unmarshal.TimeSpan);
        }
    }
}
