﻿using MarkLogic.Client.Tools.Actions;
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
        public async void ActionOptions(string[] testArgs, bool hasOptNone, bool hasOptSingle, bool hasOptMulti)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsole, MockConsole>()
                .BuildServiceProvider();

            var execContext = new TestExecContext();
            var testAction = new ActionBuilder<TestExecContext>()
                .WithVerb("test-action")
                .OnCreateExecContext(() => execContext)
                .WithOption("opt-none", "o1", deserialize: (args, optSet) => optSet.HasOptionNone = true)
                .WithOption("opt-single", "o2", 1, 1, (args, optSet) => { optSet.HasOptionSingle = true; optSet.OptionSingleArgs = args.ToArray(); })
                .WithOption("opt-multi", "o3", 1, 3, (args, optSet) => { optSet.HasOptionMulti = true; optSet.OptionMultiArgs = args.ToArray(); })
                .OnExecute((sp, optSet) =>
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
    }
}
