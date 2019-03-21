using MarkLogic.Client.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarkLogic.Client.Tests.DataServices
{
    public class MultipleParameterTests
    {
        [Fact]
        public void Name()
        {
            var paramName = "param";
            var param = new MultipleParameter<string>(paramName, true, null, Marshal.String);
            Assert.Equal(paramName, param.Name);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentNullException))]
        public void InvalidName(string paramName, Type expectedType)
        {
            Assert.Throws(expectedType, () => new MultipleParameter<string>(paramName, true, null, Marshal.String));
        }

        [Fact]
        public void NullValueNotAllowed()
        {
            Assert.Throws<ArgumentNullException>(() => new MultipleParameter<string>("param", false, null, Marshal.String));
        }

        [Fact]
        public void NullValueAllowed()
        {
            var param = new MultipleParameter<string>("param", true, null, Marshal.String);
            Assert.True(param.AllowNull);
        }

        [Theory]
        [InlineData(new string[0], 0)]
        [InlineData(new[] { "value" }, 1)]
        [InlineData(new[] { "value1", "value2" }, 2)]
        public void MarshalValues(IEnumerable<string> values, int expectedCount)
        {
            var param = new MultipleParameter<string>("param", true, values, Marshal.String);
            Assert.Equal(expectedCount, param.GetMarshals().Count());
        }
    }
}
