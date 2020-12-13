using MarkLogic.Client.DataService;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace MarkLogic.Client.Tests.DataServices
{
    public class UnmarshalTests
    {
        private static Stream CreateStream(string value)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(value);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static async Task UnmarshalValid<T>(Func<Stream, Task<T>> unmarshalMethod, T expectedValue, string testValue)
        {
            using (var stream = CreateStream(testValue))
            {
                var unmarshalledValue = await unmarshalMethod(stream);
                Assert.Equal(expectedValue, unmarshalledValue);
            }
        }

        private static async Task UnmarshalInvalid<T>(Func<Stream, Task<T>> unmarshalMethod, string testValue)
        {
            using (var stream = CreateStream(testValue))
            {
                var exception = await Assert.ThrowsAsync<UnmarshalException>(() => unmarshalMethod(stream));
                Assert.Equal(typeof(T).FullName, exception.ConvertToType.FullName);
            }
        }

        [Theory]
        [InlineData(true, "true")]
        [InlineData(true, "1")]
        [InlineData(false, "false")]
        [InlineData(false, "0")]
        public async Task BooleanValid(bool expectedValue, string testValue)
        {
            await UnmarshalValid(Unmarshal.Boolean, expectedValue, testValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData("\n")]
        [InlineData("arbitrary string")]
        [InlineData("-1")]
        [InlineData("2")]
        [InlineData("1.0")]
        [InlineData("0.0")]
        public async Task BooleanInvalid(string testValue)
        {
            await UnmarshalInvalid(Unmarshal.Boolean, testValue);
        }

        [Theory]
        [InlineData(true, "true")]
        [InlineData(true, "1")]
        [InlineData(false, "false")]
        [InlineData(false, "0")]
        [InlineData(null, "")]
        [InlineData(null, " ")]
        [InlineData(null, "\n")]
        public async Task NullableBooleanValid(bool? expectedValue, string testValue)
        {
            await UnmarshalValid(Unmarshal.Nullable(Unmarshal.Boolean), expectedValue, testValue);
        }
    }
}
