using MarkLogic.Client.DataService;
using System;
using Xunit;

namespace MarkLogic.Client.Tests.DataServices
{
    public class SingleParameterTests
    {
        [Fact]
        public void Name()
        {
            var paramName = "param";
            var param = new SingleParameter<string>(paramName, true, null, Marshal.String);
            Assert.Equal(paramName, param.Name);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentNullException))]
        public void InvalidName(string paramName, Type expectedType)
        {
            Assert.Throws(expectedType, () => new SingleParameter<int>(paramName, false, 0, Marshal.Integer));
        }
        
        [Fact]
        public void NotAllowNullReferenceType()
        {
            Assert.Throws<ArgumentNullException>(() => new SingleParameter<string>("param", false, null, Marshal.String));
        }

        [Fact]
        public void NotAllowNullValueType()
        {
            Assert.Throws<ArgumentNullException>(() => new SingleParameter<int?>("param", false, new int?(), Marshal.Nullable<int>(Marshal.Integer)));
        }

        [Fact]
        public void NullValueAllowed()
        {
            var refParam = new SingleParameter<string>("param", true, null, Marshal.String);
            var valueParam = new SingleParameter<int?>("param", true, null, Marshal.Nullable<int>(Marshal.Integer));
            Assert.True(refParam.AllowNull);
            Assert.True(valueParam.AllowNull);
        }

        [Fact]
        public void MarshalValues()
        {
            var param = new SingleParameter<string>("param", true, null, Marshal.String);
            Assert.Single(param.GetMarshals());
        }
    }
}
