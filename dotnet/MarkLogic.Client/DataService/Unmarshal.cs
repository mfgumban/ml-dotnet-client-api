using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace MarkLogic.Client.DataService
{
    public static class Unmarshal
    {
        private static async Task<string> ReadStreamAsString(Stream stream)
        {
            var reader = new StreamReader(stream);
            var value = await reader.ReadToEndAsync();
            reader.Close();
            return value;
        }
        public static async Task<bool> Boolean(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToBoolean(value);
        }

        public static async Task<string> String(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return value;
        }

        public static async Task<int> Integer(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToInt32(value);
        }

        public static async Task<uint> UnsignedInteger(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToUInt32(value);
        }

        public static async Task<long> Long(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToInt64(value);
        }

        public static async Task<ulong> UnsignedLong(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToUInt64(value);
        }

        public static async Task<float> Float(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToSingle(value);
        }

        public static async Task<double> Double(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToDouble(value);
        }

        public static async Task<decimal> Decimal(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToDecimal(value);
        }

        public static async Task<DateTime> DateTime(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);
        }

        public static async Task<DateTime> Date(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return System.DateTime.ParseExact(value, "yyyy-MM-dd", null);
        }

        public static async Task<DateTime> Time(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return System.DateTime.ParseExact(value, "HH:mm:ss.fff", null);
        }

        public static async Task<TimeSpan> TimeSpan(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return XmlConvert.ToTimeSpan(value);
        }

        public static async Task<JObject> JsonObject(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return JObject.Parse(value);
        }

        public static async Task<JArray> JsonArray(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            return JArray.Parse(value);
        }

        public static async Task<Stream> Stream(Stream stream)
        {
            // copy stream contents as the input stream may get disposed by the caller
            var newStream = new MemoryStream();
            await stream.CopyToAsync(newStream);
            newStream.Position = 0; // remember to reset position
            return newStream;
        }
    }
}