using MarkLogic.Client.Tools.Actions;
using MarkLogic.Client.Tools.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MarkLogic.Client.Tools.Tests.Actions
{
    public class ActionTests
    {
        public class TestExecContext
        {
            public TestExecContext()
            {
                OptionSingleArgs = new string[0];
                OptionMultiArgs = new string[0];
            }

            public string CommandMessage { get; set; }

            public bool HasOptionSingle { get; set; }

            public bool HasOptionMulti { get; set; }

            public bool HasOptionNone { get; set; }

            public string[] OptionSingleArgs { get; set; }

            public string[] OptionMultiArgs { get; set; }
        }

        [Theory]
        [InlineData(new[] { "--opt-none" }, true, false, false)]
        [InlineData(new[] { "--opt-none", "--opt-single", "value" }, true, true, false)]
        [InlineData(new[] { "--opt-none", "--opt-single", "value", "--opt-multi", "value1", "value2" }, true, true, true)]
        [InlineData(new[] { "-o1" }, true, false, false)]
        [InlineData(new[] { "-o1", "-o2", "value" }, true, true, false)]
        [InlineData(new[] { "-o1", "-o2", "value", "-o3", "value1", "value2" }, true, true, true)]
        public async void ActionWithOptions(string[] testArgs, bool hasOptNone, bool hasOptSingle, bool hasOptMulti)
        {
            var serviceProvider = new ServiceCollection()
                .BuildServiceProvider();

            var execContext = new TestExecContext();
            var testAction = new ActionBuilder<TestExecContext>()
                .WithVerb("test-action")
                .OnCreateExecContext(() => execContext)
                .WithOption("opt-none", "o1", deserialize: (args, context) => context.HasOptionNone = true)
                .WithOption("opt-single", "o2", false, 1, 1, (args, context) => { context.HasOptionSingle = true; context.OptionSingleArgs = args.ToArray(); })
                .WithOption("opt-multi", "o3", false, 1, 3, (args, context) => { context.HasOptionMulti = true; context.OptionMultiArgs = args.ToArray(); })
                .OnExecute((sp, context) =>
                {
                    return Task.FromResult(0);
                })
                .Create();

            var retVal = await testAction.Execute(serviceProvider, testArgs);

            Assert.Equal(hasOptNone, execContext.HasOptionNone);
            Assert.Equal(hasOptSingle, execContext.HasOptionSingle);
            Assert.Equal(hasOptSingle ? 1 : 0, execContext.OptionSingleArgs.Length);
            Assert.Equal(hasOptMulti, execContext.HasOptionMulti);
            Assert.Equal(hasOptMulti ? 2 : 0, execContext.OptionMultiArgs.Length);
        }

        [Theory]
        [InlineData(new[] { "command1" }, "command1")]
        [InlineData(new[] { "command2" }, "command2")]
        public async void CompositeAction(string[] testArgs, string expectedCmdMsg)
        {
            var execContext = new TestExecContext();
            var testAction = new CompositeActionBuilder()
                .WithVerb("test")
                .WithAction(new ActionBuilder<TestExecContext>()
                    .WithVerb("command1")
                    .OnCreateExecContext(() => execContext)
                    .OnExecute((sp, context) => { context.CommandMessage = "command1"; return Task.FromResult(0); })
                    .Create())
                .WithAction(new ActionBuilder<TestExecContext>()
                    .WithVerb("command2")
                    .OnCreateExecContext(() => execContext)
                    .OnExecute((sp, context) => { context.CommandMessage = "command2"; return Task.FromResult(0); })
                    .Create())
                .Create();

            var serviceProvider = new ServiceCollection()
                .BuildServiceProvider();

            var retVal = await testAction.Execute(serviceProvider, testArgs);

            Assert.Equal(0, retVal);
            Assert.Equal(expectedCmdMsg, execContext.CommandMessage);
        }

        [Fact]
        public async void SimpleAction()
        {
            var value = "";

            var testAction = new SimpleActionBuilder()
                .WithVerb("test")
                .OnExecute((sp) => { value = "Value changed"; return Task.FromResult(0); })
                .Create();

            var serviceProvider = new ServiceCollection()
                .BuildServiceProvider();

            var retVal = await testAction.Execute(serviceProvider, new string[0]);

            Assert.Equal(0, retVal);
            Assert.Equal("Value changed", value);
        }
    }
}
