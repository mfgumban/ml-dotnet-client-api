using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        private static async Task<T> UnmarshalValueTypeFromString<T>(Stream stream, Func<string, T> unmarshalValue)
        {
            var value = await ReadStreamAsString(stream);
            try
            {
                return unmarshalValue(value);
            }
            catch (Exception e)
            {
                throw UnmarshalException.Create(value, typeof(T), e);
            }
        }

        public static Func<Stream, Task<T?>> Nullable<T>(Func<string, T> unmarshalValue) where T : struct, IComparable
        {
            return new Func<Stream, Task<T?>>(async stream =>
            {
                var value = await ReadStreamAsString(stream);
                if (string.IsNullOrWhiteSpace(value))
                    return null;
                try
                {
                    return unmarshalValue(value);
                }
                catch (Exception e)
                {
                    throw UnmarshalException.Create(value, typeof(T?), e);
                }
            });
        }

        public static async Task<bool> Boolean(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Boolean(value));

        public static bool Boolean(string value) => XmlConvert.ToBoolean(value);

        public static async Task<string> String(Stream stream) => await ReadStreamAsString(stream);

        public static async Task<int> Integer(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Integer(value));

        public static int Integer(string value) => XmlConvert.ToInt32(value);

        public static async Task<uint> UnsignedInteger(Stream stream) => await UnmarshalValueTypeFromString(stream, value => UnsignedInteger(value));
        
        public static uint UnsignedInteger(string value) => XmlConvert.ToUInt32(value);

        public static async Task<long> Long(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Long(value));

        public static long Long(string value) => XmlConvert.ToInt64(value);

        public static async Task<ulong> UnsignedLong(Stream stream) => await UnmarshalValueTypeFromString(stream, value => UnsignedLong(value));

        public static ulong UnsignedLong(string value) => XmlConvert.ToUInt64(value);

        public static async Task<float> Float(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Float(value));

        public static float Float(string value) => XmlConvert.ToSingle(value);

        public static async Task<double> Double(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Double(value));

        public static double Double(string value) => XmlConvert.ToDouble(value);

        public static async Task<decimal> Decimal(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Decimal(value));

        public static decimal Decimal(string value) => XmlConvert.ToDecimal(value);

        public static async Task<DateTime> DateTime(Stream stream) => await UnmarshalValueTypeFromString(stream, value => DateTime(value));

        public static DateTime DateTime(string value) => XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);

        public static async Task<DateTime> Date(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Date(value));
        
        public static DateTime Date(string value) => System.DateTime.ParseExact(value, "yyyy-MM-dd", null);
    
        public static async Task<DateTime> Time(Stream stream) => await UnmarshalValueTypeFromString(stream, value => Time(value));

        public static DateTime Time(string value) => System.DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault);

        public static async Task<TimeSpan> TimeSpan(Stream stream) => await UnmarshalValueTypeFromString(stream, value => TimeSpan(value));
        
        public static TimeSpan TimeSpan(string value) => XmlConvert.ToTimeSpan(value);

        public static async Task<JObject> JsonObject(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            if (string.IsNullOrWhiteSpace(value))
                return null;
            try
            {
                return JObject.Parse(value);
            }
            catch(Exception e)
            {
                throw UnmarshalException.Create(value, typeof(JObject), e);
            }
        }

        public static async Task<JArray> JsonArray(Stream stream)
        {
            var value = await ReadStreamAsString(stream);
            if (string.IsNullOrWhiteSpace(value))
                return null;
            try
            {
                return JArray.Parse(value);
            }
            catch (Exception e)
            {
                throw UnmarshalException.Create(value, typeof(JArray), e);
            }
        }

        public static async Task<XmlDocument> XmlDocument(Stream stream)
        {
            return await Task.Run(() =>
            {
                var reader = new StreamReader(stream);
                try
                {
                    if (reader.Peek() < 0)
                        return null; // possible EOF
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(reader);
                    return xmlDoc;
                }
                catch(Exception e)
                {
                    stream.Position = 0;
                    throw UnmarshalException.Create(reader.ReadToEnd(), typeof(XmlDocument), e);
                }
            });
        }

        public static async Task<XDocument> XDocument(Stream stream)
        {
            return await Task.Run(() =>
            {
                var reader = new StreamReader(stream);
                try
                {
                    if (reader.Peek() < 0)
                        return null; // possible EOF
                    return System.Xml.Linq.XDocument.Load(reader);
                }
                catch (Exception e)
                {
                    stream.Position = 0;
                    throw UnmarshalException.Create(reader.ReadToEnd(), typeof(XmlDocument), e);
                }
            });
        }

        public static async Task<Stream> Stream(Stream stream)
        {
            // copy stream contents as the input stream may get disposed by the caller
            var newStream = new MemoryStream();
            await stream.CopyToAsync(newStream);
            newStream.Position = 0;
            return newStream;
        }
    }
}