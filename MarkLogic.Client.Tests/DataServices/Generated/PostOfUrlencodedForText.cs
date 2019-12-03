using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfUrlencodedForText/".
    /// </summary>
    public partial class PostOfUrlencodedForText : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfUrlencodedForText object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfUrlencodedForText(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfUrlencodedForText/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfUrlencodedForText object.</returns>
        public static PostOfUrlencodedForText Create(IDatabaseClient dbClient)
        {
            return new PostOfUrlencodedForText(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextTime0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime> PostOfUrlencodedForTextTime0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextTime0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime>(false, Unmarshal.Time);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextUnsignedLong0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<ulong> PostOfUrlencodedForTextUnsignedLong0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextUnsignedLong0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<ulong>(false, Unmarshal.UnsignedLong);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextLong0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<long> PostOfUrlencodedForTextLong0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextLong0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<long>(false, Unmarshal.Long);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextLong1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<long?> PostOfUrlencodedForTextLong1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextLong1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<long?>(false, Unmarshal.Nullable(Unmarshal.Long));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextUnsignedLong1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<ulong?> PostOfUrlencodedForTextUnsignedLong1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextUnsignedLong1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<ulong?>(false, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextTime1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfUrlencodedForTextTime1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextTime1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Time));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextUnsignedInt0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<uint> PostOfUrlencodedForTextUnsignedInt0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextUnsignedInt0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<uint>(false, Unmarshal.UnsignedInteger);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextFloat1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<float?> PostOfUrlencodedForTextFloat1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextFloat1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<float?>(false, Unmarshal.Nullable(Unmarshal.Float));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextUnsignedInt1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<uint?> PostOfUrlencodedForTextUnsignedInt1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextUnsignedInt1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<uint?>(false, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextBoolean1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<bool?> PostOfUrlencodedForTextBoolean1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextBoolean1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<bool?>(false, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextBoolean0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<bool> PostOfUrlencodedForTextBoolean0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextBoolean0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<bool>(false, Unmarshal.Boolean);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDateTime1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfUrlencodedForTextDateTime1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDateTime1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.DateTime));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDateTime0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime> PostOfUrlencodedForTextDateTime0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDateTime0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime>(false, Unmarshal.DateTime);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDate1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfUrlencodedForTextDate1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDate1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Date));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextFloat1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<float?> PostOfUrlencodedForTextFloat1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextFloat1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<float?>(false, Unmarshal.Nullable(Unmarshal.Float));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextFloat0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<float> PostOfUrlencodedForTextFloat0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextFloat0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<float>(false, Unmarshal.Float);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextInt1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<int?> PostOfUrlencodedForTextInt1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextInt1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<int?>(false, Unmarshal.Nullable(Unmarshal.Integer));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDecimal1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<decimal?> PostOfUrlencodedForTextDecimal1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDecimal1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<decimal?>(false, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDouble1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<double?> PostOfUrlencodedForTextDouble1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDouble1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<double?>(false, Unmarshal.Nullable(Unmarshal.Double));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDouble0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<double> PostOfUrlencodedForTextDouble0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDouble0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<double>(false, Unmarshal.Double);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDate1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfUrlencodedForTextDate1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDate1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Date));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDate0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime> PostOfUrlencodedForTextDate0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDate0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime>(false, Unmarshal.Date);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDayTimeDuration1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<TimeSpan?> PostOfUrlencodedForTextDayTimeDuration1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDayTimeDuration1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<TimeSpan?>(false, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextString1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<string> PostOfUrlencodedForTextString1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextString1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextBoolean1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<bool?> PostOfUrlencodedForTextBoolean1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextBoolean1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<bool?>(false, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextString0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<string> PostOfUrlencodedForTextString0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextString0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDouble1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<double?> PostOfUrlencodedForTextDouble1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDouble1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<double?>(false, Unmarshal.Nullable(Unmarshal.Double));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDecimal0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<decimal> PostOfUrlencodedForTextDecimal0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDecimal0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<decimal>(false, Unmarshal.Decimal);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDecimal1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<decimal?> PostOfUrlencodedForTextDecimal1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDecimal1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<decimal?>(false, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextLong1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<long?> PostOfUrlencodedForTextLong1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextLong1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<long?>(false, Unmarshal.Nullable(Unmarshal.Long));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextTime1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfUrlencodedForTextTime1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextTime1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Time));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextString1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<string> PostOfUrlencodedForTextString1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextString1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDayTimeDuration1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<TimeSpan?> PostOfUrlencodedForTextDayTimeDuration1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDayTimeDuration1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<TimeSpan?>(false, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDayTimeDuration0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<TimeSpan> PostOfUrlencodedForTextDayTimeDuration0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDayTimeDuration0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<TimeSpan>(false, Unmarshal.TimeSpan);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextUnsignedLong1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<ulong?> PostOfUrlencodedForTextUnsignedLong1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextUnsignedLong1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<ulong?>(false, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextUnsignedInt1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<uint?> PostOfUrlencodedForTextUnsignedInt1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextUnsignedInt1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<uint?>(false, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextDateTime1ReturnNull.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<DateTime?> PostOfUrlencodedForTextDateTime1ReturnNull(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextDateTime1ReturnNull.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.DateTime));
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextInt0.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<int> PostOfUrlencodedForTextInt0(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextInt0.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<int>(false, Unmarshal.Integer);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedForTextInt1.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        public Task<int?> PostOfUrlencodedForTextInt1(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedForTextInt1.xqy")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestSingle<int?>(false, Unmarshal.Nullable(Unmarshal.Integer));
        }
    }
}
