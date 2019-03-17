using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI.Actions
{
    public static class DataServiceAction
    {
        public sealed class OptionSet
        {
            public string PathToService { get; set; }
        }

        private static IAction _action;

        public static IAction Default => _action ?? (_action = new ActionBuilder<OptionSet>()
            .WithVerb("dataservice")
            .WithOption("service", shorthand: "s", minArgs: 1, maxArgs: 1, deserialize: (value, opts) => opts.PathToService = value)
            .OnCreateOptionSet(() => new OptionSet())
            .OnExecute((serviceProvider, opts) =>
            {
                var path = opts.PathToService;
                return Task.FromResult(0);
            })
            .Create());
    }
}
