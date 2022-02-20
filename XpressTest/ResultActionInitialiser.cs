namespace XpressTest;

public static class ResultActionInitialiser<TSut>
    where TSut : class
{
    public static IAsserter<System.Action<IAssertion<TSut, TResult>>> Initialise<TResult>(Func<IAction<TSut>, TResult> func)
    {
        var arrangement = ArrangementInitialiser.Initialise();

        var sutComposer = new SutComposer<TSut>(
            arrangement
            );
        
        var actionExecutor = new ResultActionExecutor<TSut, TResult>(
            func
            );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut, TResult>>(
            actionExecutor,
            arrangement
        );

        var builder = new ResultAsserter<TSut, TResult>(
            sutComposer,
            sutTesterComposer
        );

        return builder;
    }
}
