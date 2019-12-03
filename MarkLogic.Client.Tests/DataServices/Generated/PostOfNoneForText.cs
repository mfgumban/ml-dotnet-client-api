using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfNoneForText/".
    /// </summary>
    public partial class PostOfNoneForText : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfNoneForText object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfNoneForText(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfNoneForText/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfNoneForText object.</returns>
        public static PostOfNoneForText Create(IDatabaseClient dbClient)
        {
            return new PostOfNoneForText(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDecimal0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<decimal> PostOfNoneForTextDecimal0()
        {
            return CreateRequest("postOfNoneForTextDecimal0.sjs")
                .RequestSingle<decimal>(false, Unmarshal.Decimal);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDecimal1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<decimal?> PostOfNoneForTextDecimal1()
        {
            return CreateRequest("postOfNoneForTextDecimal1.sjs")
                .RequestSingle<decimal?>(false, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextFloat0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<float> PostOfNoneForTextFloat0()
        {
            return CreateRequest("postOfNoneForTextFloat0.sjs")
                .RequestSingle<float>(false, Unmarshal.Float);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDate0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime> PostOfNoneForTextDate0()
        {
            return CreateRequest("postOfNoneForTextDate0.sjs")
                .RequestSingle<DateTime>(false, Unmarshal.Date);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDate1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime?> PostOfNoneForTextDate1()
        {
            return CreateRequest("postOfNoneForTextDate1.sjs")
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Date));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextFloat1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<float?> PostOfNoneForTextFloat1()
        {
            return CreateRequest("postOfNoneForTextFloat1.sjs")
                .RequestSingle<float?>(false, Unmarshal.Nullable(Unmarshal.Float));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextUnsignedInt1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<uint?> PostOfNoneForTextUnsignedInt1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextUnsignedInt1ReturnNull.sjs")
                .RequestSingle<uint?>(false, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextString0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<string> PostOfNoneForTextString0()
        {
            return CreateRequest("postOfNoneForTextString0.sjs")
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextString1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<string> PostOfNoneForTextString1()
        {
            return CreateRequest("postOfNoneForTextString1.sjs")
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextTime1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime?> PostOfNoneForTextTime1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextTime1ReturnNull.sjs")
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Time));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextLong1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<long?> PostOfNoneForTextLong1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextLong1ReturnNull.sjs")
                .RequestSingle<long?>(false, Unmarshal.Nullable(Unmarshal.Long));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDayTimeDuration1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<TimeSpan?> PostOfNoneForTextDayTimeDuration1()
        {
            return CreateRequest("postOfNoneForTextDayTimeDuration1.sjs")
                .RequestSingle<TimeSpan?>(false, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextBoolean1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<bool?> PostOfNoneForTextBoolean1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextBoolean1ReturnNull.sjs")
                .RequestSingle<bool?>(false, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDateTime1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime?> PostOfNoneForTextDateTime1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextDateTime1ReturnNull.sjs")
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.DateTime));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDayTimeDuration0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<TimeSpan> PostOfNoneForTextDayTimeDuration0()
        {
            return CreateRequest("postOfNoneForTextDayTimeDuration0.sjs")
                .RequestSingle<TimeSpan>(false, Unmarshal.TimeSpan);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextUnsignedLong1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<ulong?> PostOfNoneForTextUnsignedLong1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextUnsignedLong1ReturnNull.sjs")
                .RequestSingle<ulong?>(false, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextBoolean1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<bool?> PostOfNoneForTextBoolean1()
        {
            return CreateRequest("postOfNoneForTextBoolean1.sjs")
                .RequestSingle<bool?>(false, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDouble1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<double?> PostOfNoneForTextDouble1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextDouble1ReturnNull.sjs")
                .RequestSingle<double?>(false, Unmarshal.Nullable(Unmarshal.Double));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextBoolean0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<bool> PostOfNoneForTextBoolean0()
        {
            return CreateRequest("postOfNoneForTextBoolean0.sjs")
                .RequestSingle<bool>(false, Unmarshal.Boolean);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextInt1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<int?> PostOfNoneForTextInt1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextInt1ReturnNull.sjs")
                .RequestSingle<int?>(false, Unmarshal.Nullable(Unmarshal.Integer));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDecimal1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<decimal?> PostOfNoneForTextDecimal1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextDecimal1ReturnNull.sjs")
                .RequestSingle<decimal?>(false, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextTime1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime?> PostOfNoneForTextTime1()
        {
            return CreateRequest("postOfNoneForTextTime1.sjs")
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Time));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextUnsignedLong1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<ulong?> PostOfNoneForTextUnsignedLong1()
        {
            return CreateRequest("postOfNoneForTextUnsignedLong1.sjs")
                .RequestSingle<ulong?>(false, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextString1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<string> PostOfNoneForTextString1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextString1ReturnNull.sjs")
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextLong1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<long?> PostOfNoneForTextLong1()
        {
            return CreateRequest("postOfNoneForTextLong1.sjs")
                .RequestSingle<long?>(false, Unmarshal.Nullable(Unmarshal.Long));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDayTimeDuration1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<TimeSpan?> PostOfNoneForTextDayTimeDuration1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextDayTimeDuration1ReturnNull.sjs")
                .RequestSingle<TimeSpan?>(false, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextLong0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<long> PostOfNoneForTextLong0()
        {
            return CreateRequest("postOfNoneForTextLong0.sjs")
                .RequestSingle<long>(false, Unmarshal.Long);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextUnsignedLong0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<ulong> PostOfNoneForTextUnsignedLong0()
        {
            return CreateRequest("postOfNoneForTextUnsignedLong0.sjs")
                .RequestSingle<ulong>(false, Unmarshal.UnsignedLong);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextTime0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime> PostOfNoneForTextTime0()
        {
            return CreateRequest("postOfNoneForTextTime0.sjs")
                .RequestSingle<DateTime>(false, Unmarshal.Time);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextInt1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<int?> PostOfNoneForTextInt1()
        {
            return CreateRequest("postOfNoneForTextInt1.sjs")
                .RequestSingle<int?>(false, Unmarshal.Nullable(Unmarshal.Integer));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextFloat1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<float?> PostOfNoneForTextFloat1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextFloat1ReturnNull.sjs")
                .RequestSingle<float?>(false, Unmarshal.Nullable(Unmarshal.Float));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextInt0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<int> PostOfNoneForTextInt0()
        {
            return CreateRequest("postOfNoneForTextInt0.sjs")
                .RequestSingle<int>(false, Unmarshal.Integer);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDouble0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<double> PostOfNoneForTextDouble0()
        {
            return CreateRequest("postOfNoneForTextDouble0.sjs")
                .RequestSingle<double>(false, Unmarshal.Double);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDouble1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<double?> PostOfNoneForTextDouble1()
        {
            return CreateRequest("postOfNoneForTextDouble1.sjs")
                .RequestSingle<double?>(false, Unmarshal.Nullable(Unmarshal.Double));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextUnsignedInt0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<uint> PostOfNoneForTextUnsignedInt0()
        {
            return CreateRequest("postOfNoneForTextUnsignedInt0.sjs")
                .RequestSingle<uint>(false, Unmarshal.UnsignedInteger);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDate1ReturnNull.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime?> PostOfNoneForTextDate1ReturnNull()
        {
            return CreateRequest("postOfNoneForTextDate1ReturnNull.sjs")
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.Date));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextUnsignedInt1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<uint?> PostOfNoneForTextUnsignedInt1()
        {
            return CreateRequest("postOfNoneForTextUnsignedInt1.sjs")
                .RequestSingle<uint?>(false, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDateTime0.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime> PostOfNoneForTextDateTime0()
        {
            return CreateRequest("postOfNoneForTextDateTime0.sjs")
                .RequestSingle<DateTime>(false, Unmarshal.DateTime);
        }

        /// <summary>
        /// Invokes the "postOfNoneForTextDateTime1.sjs" data service endpoint.
        /// </summary>
        /// <returns></returns>
        public Task<DateTime?> PostOfNoneForTextDateTime1()
        {
            return CreateRequest("postOfNoneForTextDateTime1.sjs")
                .RequestSingle<DateTime?>(false, Unmarshal.Nullable(Unmarshal.DateTime));
        }
    }
}
