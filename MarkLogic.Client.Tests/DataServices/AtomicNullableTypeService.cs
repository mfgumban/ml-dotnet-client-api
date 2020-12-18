using MarkLogic.Client.DataService;
using System;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class AtomicNullableTypeService : DataServiceBase
    {
        protected AtomicNullableTypeService(IDatabaseClient dbClient) : base(dbClient, "/test/nullable-atomics/")
        {
        }

        public static AtomicNullableTypeService Create(IDatabaseClient dbClient)
        {
            return new AtomicNullableTypeService(dbClient);
        }

        public Task<bool?> ReturnBoolean(bool? value)
        {
            return CreateRequest("returnBoolean.sjs")
                .WithParameters(
                    new SingleParameter<bool?>("value", true, value, Marshal.Nullable<bool>(Marshal.Boolean)))
                .RequestSingle<bool?>(true, Unmarshal.Nullable(Unmarshal.Boolean));
        }

        public Task<string> ReturnString(string value)
        {
            return CreateRequest("returnString.sjs")
                .WithParameters(
                    new SingleParameter<string>("value", true, value, Marshal.String))
                .RequestSingle<string>(true, Unmarshal.String);
        }

        public Task<int?> ReturnInteger(int? value)
        {
            return CreateRequest("returnInteger.sjs")
                .WithParameters(
                    new SingleParameter<int?>("value", true, value, Marshal.Nullable<int>(Marshal.Integer)))
                .RequestSingle<int?>(true, Unmarshal.Nullable(Unmarshal.Integer));
        }

        public Task<uint?> ReturnUnsignedInteger(uint? value)
        {
            return CreateRequest("returnUnsignedInteger.sjs")
                .WithParameters(
                    new SingleParameter<uint?>("value", true, value, Marshal.Nullable<uint>(Marshal.UnsignedInteger)))
                .RequestSingle<uint?>(true, Unmarshal.Nullable(Unmarshal.UnsignedInteger));
        }

        public Task<long?> ReturnLong(long? value)
        {
            return CreateRequest("returnLong.sjs")
                .WithParameters(
                    new SingleParameter<long?>("value", true, value, Marshal.Nullable<long>(Marshal.Long)))
                .RequestSingle<long?>(true, Unmarshal.Nullable(Unmarshal.Long));
        }

        public Task<ulong?> ReturnUnsignedLong(ulong? value)
        {
            return CreateRequest("returnUnsignedLong.sjs")
                .WithParameters(
                    new SingleParameter<ulong?>("value", true, value, Marshal.Nullable<ulong>(Marshal.UnsignedLong)))
                .RequestSingle<ulong?>(true, Unmarshal.Nullable(Unmarshal.UnsignedLong));
        }

        public Task<float?> ReturnFloat(float? value)
        {
            return CreateRequest("returnFloat.sjs")
                .WithParameters(
                    new SingleParameter<float?>("value", true, value, Marshal.Nullable<float>(Marshal.Float)))
                .RequestSingle<float?>(true, Unmarshal.Nullable(Unmarshal.Float));
        }

        public Task<double?> ReturnDouble(double? value)
        {
            return CreateRequest("returnDouble.sjs")
                .WithParameters(
                    new SingleParameter<double?>("value", true, value, Marshal.Nullable<double>(Marshal.Double)))
                .RequestSingle<double?>(true, Unmarshal.Nullable(Unmarshal.Double));
        }

        public Task<decimal?> ReturnDecimal(decimal? value)
        {
            return CreateRequest("returnDecimal.sjs")
                .WithParameters(
                    new SingleParameter<decimal?>("value", true, value, Marshal.Nullable<decimal>(Marshal.Decimal)))
                .RequestSingle<decimal?>(true, Unmarshal.Nullable(Unmarshal.Decimal));
        }

        public Task<DateTime?> ReturnDateTime(DateTime? value)
        {
            return CreateRequest("returnDateTime.sjs")
                .WithParameters(
                    new SingleParameter<DateTime?>("value", true, value, Marshal.Nullable<DateTime>(Marshal.DateTime)))
                .RequestSingle<DateTime?>(true, Unmarshal.Nullable(Unmarshal.DateTime));
        }

        public Task<DateTime?> ReturnDate(DateTime? value)
        {
            return CreateRequest("returnDate.sjs")
                .WithParameters(
                    new SingleParameter<DateTime?>("value", true, value, Marshal.Nullable<DateTime>(Marshal.Date)))
                .RequestSingle<DateTime?>(true, Unmarshal.Nullable(Unmarshal.Date));
        }

        public Task<DateTime?> ReturnTime(DateTime? value)
        {
            return CreateRequest("returnTime.sjs")
                .WithParameters(
                    new SingleParameter<DateTime?>("value", true, value, Marshal.Nullable<DateTime>(Marshal.Time)))
                .RequestSingle<DateTime?>(true, Unmarshal.Nullable(Unmarshal.Time));
        }

        public Task<TimeSpan?> ReturnTimeSpan(TimeSpan? value)
        {
            return CreateRequest("returnTimeSpan.sjs")
                .WithParameters(
                    new SingleParameter<TimeSpan?>("value", true, value, Marshal.Nullable<TimeSpan>(Marshal.TimeSpan)))
                .RequestSingle<TimeSpan?>(true, Unmarshal.Nullable(Unmarshal.TimeSpan));
        }
    }
}
