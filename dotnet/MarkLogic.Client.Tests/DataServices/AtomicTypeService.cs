using MarkLogic.Client.DataService;
using System;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class AtomicTypeService : DataServiceBase
    {
        protected AtomicTypeService(IDatabaseClient dbClient) : base(dbClient, "/test/atomics/")
        {
        }

        public static AtomicTypeService Create(IDatabaseClient dbClient)
        {
            return new AtomicTypeService(dbClient);
        }

        public Task<int?> ReturnNullableValueType(int? value)
        {
            return CreateRequest("returnNullableValueType.xqy")
                .WithParameters(
                    new SingleParameter<int?>("value", true, value, Marshal.Nullable<int>(Marshal.Integer)))
                .RequestSingle<int?>(true, Unmarshal.Nullable(Unmarshal.Integer));
        }

        public Task<bool> ReturnBoolean(bool value)
        {
            return CreateRequest("returnBoolean.xqy")
                .WithParameters(
                    new SingleParameter<bool>("value", false, value, Marshal.Boolean))
                .RequestSingle<bool>(false, Unmarshal.Boolean);
        }

        public Task<string> ReturnString(string value)
        {
            return CreateRequest("returnString.xqy")
                .WithParameters(
                    new SingleParameter<string>("value", false, value, Marshal.String))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        public Task<int> ReturnInteger(int value)
        {
            return CreateRequest("returnInteger.xqy")
                .WithParameters(
                    new SingleParameter<int>("value", false, value, Marshal.Integer))
                .RequestSingle<int>(false, Unmarshal.Integer);
        }

        public Task<uint> ReturnUnsignedInteger(uint value)
        {
            return CreateRequest("returnUnsignedInteger.xqy")
                .WithParameters(
                    new SingleParameter<uint>("value", false, value, Marshal.UnsignedInteger))
                .RequestSingle<uint>(false, Unmarshal.UnsignedInteger);
        }

        public Task<long> ReturnLong(long value)
        {
            return CreateRequest("returnLong.xqy")
                .WithParameters(
                    new SingleParameter<long>("value", false, value, Marshal.Long))
                .RequestSingle<long>(false, Unmarshal.Long);
        }

        public Task<ulong> ReturnUnsignedLong(ulong value)
        {
            return CreateRequest("returnUnsignedLong.xqy")
                .WithParameters(
                    new SingleParameter<ulong>("value", false, value, Marshal.UnsignedLong))
                .RequestSingle<ulong>(false, Unmarshal.UnsignedLong);
        }

        public Task<float> ReturnFloat(float value)
        {
            return CreateRequest("returnFloat.xqy")
                .WithParameters(
                    new SingleParameter<float>("value", false, value, Marshal.Float))
                .RequestSingle<float>(false, Unmarshal.Float);
        }

        public Task<double> ReturnDouble(double value)
        {
            return CreateRequest("returnDouble.xqy")
                .WithParameters(
                    new SingleParameter<double>("value", false, value, Marshal.Double))
                .RequestSingle<double>(false, Unmarshal.Double);
        }

        public Task<decimal> ReturnDecimal(decimal value)
        {
            return CreateRequest("returnDecimal.xqy")
                .WithParameters(
                    new SingleParameter<decimal>("value", false, value, Marshal.Decimal))
                .RequestSingle<decimal>(false, Unmarshal.Decimal);
        }

        public Task<DateTime> ReturnDateTime(DateTime value)
        {
            return CreateRequest("returnDateTime.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.DateTime))
                .RequestSingle<DateTime>(false, Unmarshal.DateTime);
        }

        public Task<DateTime> ReturnDate(DateTime value)
        {
            return CreateRequest("returnDate.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.Date))
                .RequestSingle<DateTime>(false, Unmarshal.Date);
        }

        public Task<DateTime> ReturnTime(DateTime value)
        {
            return CreateRequest("returnTime.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.Time))
                .RequestSingle<DateTime>(false, Unmarshal.Time);
        }

        public Task<TimeSpan> ReturnTimeSpan(TimeSpan value)
        {
            return CreateRequest("returnTimeSpan.xqy")
                .WithParameters(
                    new SingleParameter<TimeSpan>("value", false, value, Marshal.TimeSpan))
                .RequestSingle<TimeSpan>(false, Unmarshal.TimeSpan);
        }
    }
}
