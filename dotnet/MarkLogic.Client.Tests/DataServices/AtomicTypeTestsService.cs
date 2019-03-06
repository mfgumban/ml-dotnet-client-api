using MarkLogic.Client.DataService;
using System;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class AtomicTypeTestsService : DataServiceBase
    {
        protected AtomicTypeTestsService(IDatabaseClient dbClient) : base(dbClient, "/test/atomics/")
        {
        }

        public static AtomicTypeTestsService Create(IDatabaseClient dbClient)
        {
            return new AtomicTypeTestsService(dbClient);
        }

        public Task<bool> returnBoolean(bool value)
        {
            return CreateRequest("returnBoolean.xqy")
                .WithParameters(
                    new SingleParameter<bool>("value", false, value, Marshal.Boolean))
                .RequestSingle<bool>(false, Unmarshal.Boolean);
        }

        public Task<string> returnString(string value)
        {
            return CreateRequest("returnString.xqy")
                .WithParameters(
                    new SingleParameter<string>("value", false, value, Marshal.String))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        public Task<int> returnInteger(int value)
        {
            return CreateRequest("returnInteger.xqy")
                .WithParameters(
                    new SingleParameter<int>("value", false, value, Marshal.Integer))
                .RequestSingle<int>(false, Unmarshal.Integer);
        }

        public Task<uint> returnUnsignedInteger(uint value)
        {
            return CreateRequest("returnUnsignedInteger.xqy")
                .WithParameters(
                    new SingleParameter<uint>("value", false, value, Marshal.UnsignedInteger))
                .RequestSingle<uint>(false, Unmarshal.UnsignedInteger);
        }

        public Task<long> returnLong(long value)
        {
            return CreateRequest("returnLong.xqy")
                .WithParameters(
                    new SingleParameter<long>("value", false, value, Marshal.Long))
                .RequestSingle<long>(false, Unmarshal.Long);
        }

        public Task<ulong> returnUnsignedLong(ulong value)
        {
            return CreateRequest("returnUnsignedLong.xqy")
                .WithParameters(
                    new SingleParameter<ulong>("value", false, value, Marshal.UnsignedLong))
                .RequestSingle<ulong>(false, Unmarshal.UnsignedLong);
        }

        public Task<float> returnFloat(float value)
        {
            return CreateRequest("returnFloat.xqy")
                .WithParameters(
                    new SingleParameter<float>("value", false, value, Marshal.Float))
                .RequestSingle<float>(false, Unmarshal.Float);
        }

        public Task<double> returnDouble(double value)
        {
            return CreateRequest("returnDouble.xqy")
                .WithParameters(
                    new SingleParameter<double>("value", false, value, Marshal.Double))
                .RequestSingle<double>(false, Unmarshal.Double);
        }

        public Task<decimal> returnDecimal(decimal value)
        {
            return CreateRequest("returnDecimal.xqy")
                .WithParameters(
                    new SingleParameter<decimal>("value", false, value, Marshal.Decimal))
                .RequestSingle<decimal>(false, Unmarshal.Decimal);
        }

        public Task<DateTime> returnDateTime(DateTime value)
        {
            return CreateRequest("returnDateTime.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.DateTime))
                .RequestSingle<DateTime>(false, Unmarshal.DateTime);
        }

        public Task<DateTime> returnDate(DateTime value)
        {
            return CreateRequest("returnDate.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.Date))
                .RequestSingle<DateTime>(false, Unmarshal.Date);
        }

        public Task<DateTime> returnTime(DateTime value)
        {
            return CreateRequest("returnTime.xqy")
                .WithParameters(
                    new SingleParameter<DateTime>("value", false, value, Marshal.Time))
                .RequestSingle<DateTime>(false, Unmarshal.Time);
        }

        public Task<TimeSpan> returnTimeSpan(TimeSpan value)
        {
            return CreateRequest("returnTimeSpan.xqy")
                .WithParameters(
                    new SingleParameter<TimeSpan>("value", false, value, Marshal.TimeSpan))
                .RequestSingle<TimeSpan>(false, Unmarshal.TimeSpan);
        }
    }
}
