namespace XpressTest;

public static class ActionInitialiser<TSut>
    where TSut : class
{
    public static IAsserter<System.Action<IArrangement>> Initialise(System.Action<IAction<TSut>> action)
    {
        var arrangement = ArrangementInitialiser.Initialise();

        var sutComposer = new SutComposer<TSut>(
            arrangement
        );
        
        var actionExecutor = new VoidActionExecutor<TSut>(
            action
            );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut>>(
            actionExecutor,
            arrangement
            );

        var builder = new VoidAsserter<TSut>(
            sutComposer,
            sutTesterComposer
        );

        return builder;
    }
}
