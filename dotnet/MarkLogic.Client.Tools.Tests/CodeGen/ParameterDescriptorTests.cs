using Xunit;

namespace MarkLogic.Client.Tools.Tests.CodeGen
{
    public class ParameterDescriptorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("param", "param")]
        [InlineData("param123", "param123")]
        [InlineData("p1arg1", "p1arg1")]
        [InlineData("1st", "_1st")]
        [InlineData("_param_", "_param_")]
        [InlineData("My Param", "My_Param")]
        [InlineData("param#1", "param_1")]
        [InlineData("^Some!Param100@@Func X", "_Some_Param100_Func_X")]
        public void ArgumentName(string paramName, string expectedArgName)
        {
            var paramDesc = new ParameterDescriptor() { Name = paramName };
            Assert.Equal(expectedArgName, paramDesc.ArgumentName);
        }
    }
}
