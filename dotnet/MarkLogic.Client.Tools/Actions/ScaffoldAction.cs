namespace MarkLogic.Client.Tools.Actions
{
    public static class ScaffoldAction
    {
        private static IAction _action;

        public static IAction Default => _action ?? (_action = new CompositeActionBuilder()
            .WithVerb("scaffold")
            .WithAction(DataServiceAction.Default)
            .Create());
    }
}
