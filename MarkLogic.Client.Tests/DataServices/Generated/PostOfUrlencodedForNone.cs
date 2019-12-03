using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfUrlencodedForNone/".
    /// </summary>
    public partial class PostOfUrlencodedForNone : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfUrlencodedForNone object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfUrlencodedForNone(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfUrlencodedForNone/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfUrlencodedForNone object.</returns>
        public static PostOfUrlencodedForNone Create(IDatabaseClient dbClient)
        {
            return new PostOfUrlencodedForNone(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedAllForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <param name="param5"></param>
        /// <param name="param6"></param>
        /// <param name="param7"></param>
        /// <param name="param8"></param>
        /// <param name="param9"></param>
        /// <param name="param10"></param>
        /// <param name="param11"></param>
        /// <param name="param12"></param>
        /// <param name="param13"></param>
        public Task PostOfUrlencodedAllForNone0(IEnumerable<bool?> param1, double param2, float? param3, IEnumerable<int> param4, long? param5, uint param6, IEnumerable<ulong?> param7, DateTime param8, DateTime? param9, IEnumerable<TimeSpan> param10, decimal? param11, string param12, IEnumerable<DateTime?> param13)
        {
            return CreateRequest("postOfUrlencodedAllForNone0.sjs")
                .WithParameters(
                    new MultipleParameter<bool?>("param1", true, param1, Marshal.Nullable<bool>(Marshal.Boolean)), 
                    new SingleParameter<double>("param2", false, param2, Marshal.Double), 
                    new SingleParameter<float?>("param3", true, param3, Marshal.Nullable<float>(Marshal.Float)), 
                    new MultipleParameter<int>("param4", false, param4, Marshal.Integer), 
                    new SingleParameter<long?>("param5", true, param5, Marshal.Nullable<long>(Marshal.Long)), 
                    new SingleParameter<uint>("param6", false, param6, Marshal.UnsignedInteger), 
                    new MultipleParameter<ulong?>("param7", true, param7, Marshal.Nullable<ulong>(Marshal.UnsignedLong)), 
                    new SingleParameter<DateTime>("param8", false, param8, Marshal.Date), 
                    new SingleParameter<DateTime?>("param9", true, param9, Marshal.Nullable<DateTime>(Marshal.DateTime)), 
                    new MultipleParameter<TimeSpan>("param10", false, param10, Marshal.TimeSpan), 
                    new SingleParameter<decimal?>("param11", true, param11, Marshal.Nullable<decimal>(Marshal.Decimal)), 
                    new SingleParameter<string>("param12", false, param12, Marshal.String), 
                    new MultipleParameter<DateTime?>("param13", true, param13, Marshal.Nullable<DateTime>(Marshal.Time)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedLongForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedLongForNone1(long? param1)
        {
            return CreateRequest("postOfUrlencodedLongForNone1.sjs")
                .WithParameters(
                    new SingleParameter<long?>("param1", true, param1, Marshal.Nullable<long>(Marshal.Long)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedLongForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedLongForNone0(long param1)
        {
            return CreateRequest("postOfUrlencodedLongForNone0.sjs")
                .WithParameters(
                    new SingleParameter<long>("param1", false, param1, Marshal.Long))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedLongForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedLongForNone2(IEnumerable<long> param1)
        {
            return CreateRequest("postOfUrlencodedLongForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<long>("param1", false, param1, Marshal.Long))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedLongForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedLongForNone3(IEnumerable<long?> param1)
        {
            return CreateRequest("postOfUrlencodedLongForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<long?>("param1", true, param1, Marshal.Nullable<long>(Marshal.Long)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedTimeForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedTimeForNone3(IEnumerable<DateTime?> param1)
        {
            return CreateRequest("postOfUrlencodedTimeForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<DateTime?>("param1", true, param1, Marshal.Nullable<DateTime>(Marshal.Time)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedTimeForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedTimeForNone2(IEnumerable<DateTime> param1)
        {
            return CreateRequest("postOfUrlencodedTimeForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<DateTime>("param1", false, param1, Marshal.Time))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedTimeForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedTimeForNone0(DateTime param1)
        {
            return CreateRequest("postOfUrlencodedTimeForNone0.sjs")
                .WithParameters(
                    new SingleParameter<DateTime>("param1", false, param1, Marshal.Time))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedTimeForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedTimeForNone1(DateTime? param1)
        {
            return CreateRequest("postOfUrlencodedTimeForNone1.sjs")
                .WithParameters(
                    new SingleParameter<DateTime?>("param1", true, param1, Marshal.Nullable<DateTime>(Marshal.Time)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedBooleanForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedBooleanForNone2(IEnumerable<bool> param1)
        {
            return CreateRequest("postOfUrlencodedBooleanForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<bool>("param1", false, param1, Marshal.Boolean))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDayTimeDurationForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDayTimeDurationForNone0(TimeSpan param1)
        {
            return CreateRequest("postOfUrlencodedDayTimeDurationForNone0.sjs")
                .WithParameters(
                    new SingleParameter<TimeSpan>("param1", false, param1, Marshal.TimeSpan))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateForNone0(DateTime param1)
        {
            return CreateRequest("postOfUrlencodedDateForNone0.sjs")
                .WithParameters(
                    new SingleParameter<DateTime>("param1", false, param1, Marshal.Date))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateForNone1(DateTime? param1)
        {
            return CreateRequest("postOfUrlencodedDateForNone1.sjs")
                .WithParameters(
                    new SingleParameter<DateTime?>("param1", true, param1, Marshal.Nullable<DateTime>(Marshal.Date)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDayTimeDurationForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDayTimeDurationForNone1(TimeSpan? param1)
        {
            return CreateRequest("postOfUrlencodedDayTimeDurationForNone1.sjs")
                .WithParameters(
                    new SingleParameter<TimeSpan?>("param1", true, param1, Marshal.Nullable<TimeSpan>(Marshal.TimeSpan)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedBooleanForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedBooleanForNone3(IEnumerable<bool?> param1)
        {
            return CreateRequest("postOfUrlencodedBooleanForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<bool?>("param1", true, param1, Marshal.Nullable<bool>(Marshal.Boolean)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedBooleanForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedBooleanForNone1(bool? param1)
        {
            return CreateRequest("postOfUrlencodedBooleanForNone1.sjs")
                .WithParameters(
                    new SingleParameter<bool?>("param1", true, param1, Marshal.Nullable<bool>(Marshal.Boolean)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDayTimeDurationForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDayTimeDurationForNone3(IEnumerable<TimeSpan?> param1)
        {
            return CreateRequest("postOfUrlencodedDayTimeDurationForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<TimeSpan?>("param1", true, param1, Marshal.Nullable<TimeSpan>(Marshal.TimeSpan)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateForNone3(IEnumerable<DateTime?> param1)
        {
            return CreateRequest("postOfUrlencodedDateForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<DateTime?>("param1", true, param1, Marshal.Nullable<DateTime>(Marshal.Date)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateForNone2(IEnumerable<DateTime> param1)
        {
            return CreateRequest("postOfUrlencodedDateForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<DateTime>("param1", false, param1, Marshal.Date))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDayTimeDurationForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDayTimeDurationForNone2(IEnumerable<TimeSpan> param1)
        {
            return CreateRequest("postOfUrlencodedDayTimeDurationForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<TimeSpan>("param1", false, param1, Marshal.TimeSpan))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedBooleanForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedBooleanForNone0(bool param1)
        {
            return CreateRequest("postOfUrlencodedBooleanForNone0.sjs")
                .WithParameters(
                    new SingleParameter<bool>("param1", false, param1, Marshal.Boolean))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateTimeForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateTimeForNone1(DateTime? param1)
        {
            return CreateRequest("postOfUrlencodedDateTimeForNone1.sjs")
                .WithParameters(
                    new SingleParameter<DateTime?>("param1", true, param1, Marshal.Nullable<DateTime>(Marshal.DateTime)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateTimeForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateTimeForNone0(DateTime param1)
        {
            return CreateRequest("postOfUrlencodedDateTimeForNone0.sjs")
                .WithParameters(
                    new SingleParameter<DateTime>("param1", false, param1, Marshal.DateTime))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateTimeForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateTimeForNone2(IEnumerable<DateTime> param1)
        {
            return CreateRequest("postOfUrlencodedDateTimeForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<DateTime>("param1", false, param1, Marshal.DateTime))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDateTimeForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDateTimeForNone3(IEnumerable<DateTime?> param1)
        {
            return CreateRequest("postOfUrlencodedDateTimeForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<DateTime?>("param1", true, param1, Marshal.Nullable<DateTime>(Marshal.DateTime)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedLongForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedLongForNone2(IEnumerable<ulong> param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedLongForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<ulong>("param1", false, param1, Marshal.UnsignedLong))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedFloatForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedFloatForNone1(float? param1)
        {
            return CreateRequest("postOfUrlencodedFloatForNone1.sjs")
                .WithParameters(
                    new SingleParameter<float?>("param1", true, param1, Marshal.Nullable<float>(Marshal.Float)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedIntForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedIntForNone2(IEnumerable<int> param1)
        {
            return CreateRequest("postOfUrlencodedIntForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDoubleForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDoubleForNone0(double param1)
        {
            return CreateRequest("postOfUrlencodedDoubleForNone0.sjs")
                .WithParameters(
                    new SingleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedStringForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedStringForNone0(string param1)
        {
            return CreateRequest("postOfUrlencodedStringForNone0.sjs")
                .WithParameters(
                    new SingleParameter<string>("param1", false, param1, Marshal.String))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedStringForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedStringForNone1(string param1)
        {
            return CreateRequest("postOfUrlencodedStringForNone1.sjs")
                .WithParameters(
                    new SingleParameter<string>("param1", true, param1, Marshal.String))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDoubleForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDoubleForNone1(double? param1)
        {
            return CreateRequest("postOfUrlencodedDoubleForNone1.sjs")
                .WithParameters(
                    new SingleParameter<double?>("param1", true, param1, Marshal.Nullable<double>(Marshal.Double)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedIntForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedIntForNone3(IEnumerable<int?> param1)
        {
            return CreateRequest("postOfUrlencodedIntForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<int?>("param1", true, param1, Marshal.Nullable<int>(Marshal.Integer)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedFloatForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedFloatForNone0(float param1)
        {
            return CreateRequest("postOfUrlencodedFloatForNone0.sjs")
                .WithParameters(
                    new SingleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedLongForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedLongForNone3(IEnumerable<ulong?> param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedLongForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<ulong?>("param1", true, param1, Marshal.Nullable<ulong>(Marshal.UnsignedLong)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedLongForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedLongForNone1(ulong? param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedLongForNone1.sjs")
                .WithParameters(
                    new SingleParameter<ulong?>("param1", true, param1, Marshal.Nullable<ulong>(Marshal.UnsignedLong)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedFloatForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedFloatForNone2(IEnumerable<float> param1)
        {
            return CreateRequest("postOfUrlencodedFloatForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<float>("param1", false, param1, Marshal.Float))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedIntForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedIntForNone1(int? param1)
        {
            return CreateRequest("postOfUrlencodedIntForNone1.sjs")
                .WithParameters(
                    new SingleParameter<int?>("param1", true, param1, Marshal.Nullable<int>(Marshal.Integer)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDoubleForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDoubleForNone3(IEnumerable<double?> param1)
        {
            return CreateRequest("postOfUrlencodedDoubleForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<double?>("param1", true, param1, Marshal.Nullable<double>(Marshal.Double)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedStringForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedStringForNone3(IEnumerable<string> param1)
        {
            return CreateRequest("postOfUrlencodedStringForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<string>("param1", true, param1, Marshal.String))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedStringForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedStringForNone2(IEnumerable<string> param1)
        {
            return CreateRequest("postOfUrlencodedStringForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<string>("param1", false, param1, Marshal.String))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDoubleForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDoubleForNone2(IEnumerable<double> param1)
        {
            return CreateRequest("postOfUrlencodedDoubleForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<double>("param1", false, param1, Marshal.Double))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedIntForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedIntForNone0(int param1)
        {
            return CreateRequest("postOfUrlencodedIntForNone0.sjs")
                .WithParameters(
                    new SingleParameter<int>("param1", false, param1, Marshal.Integer))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedFloatForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedFloatForNone3(IEnumerable<float?> param1)
        {
            return CreateRequest("postOfUrlencodedFloatForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<float?>("param1", true, param1, Marshal.Nullable<float>(Marshal.Float)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedLongForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedLongForNone0(ulong param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedLongForNone0.sjs")
                .WithParameters(
                    new SingleParameter<ulong>("param1", false, param1, Marshal.UnsignedLong))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedIntForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedIntForNone3(IEnumerable<uint?> param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedIntForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<uint?>("param1", true, param1, Marshal.Nullable<uint>(Marshal.UnsignedInteger)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedIntForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedIntForNone2(IEnumerable<uint> param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedIntForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<uint>("param1", false, param1, Marshal.UnsignedInteger))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedIntForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedIntForNone0(uint param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedIntForNone0.sjs")
                .WithParameters(
                    new SingleParameter<uint>("param1", false, param1, Marshal.UnsignedInteger))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedUnsignedIntForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedUnsignedIntForNone1(uint? param1)
        {
            return CreateRequest("postOfUrlencodedUnsignedIntForNone1.sjs")
                .WithParameters(
                    new SingleParameter<uint?>("param1", true, param1, Marshal.Nullable<uint>(Marshal.UnsignedInteger)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDecimalForNone0.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDecimalForNone0(decimal param1)
        {
            return CreateRequest("postOfUrlencodedDecimalForNone0.sjs")
                .WithParameters(
                    new SingleParameter<decimal>("param1", false, param1, Marshal.Decimal))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDecimalForNone1.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDecimalForNone1(decimal? param1)
        {
            return CreateRequest("postOfUrlencodedDecimalForNone1.sjs")
                .WithParameters(
                    new SingleParameter<decimal?>("param1", true, param1, Marshal.Nullable<decimal>(Marshal.Decimal)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDecimalForNone3.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDecimalForNone3(IEnumerable<decimal?> param1)
        {
            return CreateRequest("postOfUrlencodedDecimalForNone3.sjs")
                .WithParameters(
                    new MultipleParameter<decimal?>("param1", true, param1, Marshal.Nullable<decimal>(Marshal.Decimal)))
                .RequestNone();
        }

        /// <summary>
        /// Invokes the "postOfUrlencodedDecimalForNone2.sjs" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        public Task PostOfUrlencodedDecimalForNone2(IEnumerable<decimal> param1)
        {
            return CreateRequest("postOfUrlencodedDecimalForNone2.sjs")
                .WithParameters(
                    new MultipleParameter<decimal>("param1", false, param1, Marshal.Decimal))
                .RequestNone();
        }
    }
}
