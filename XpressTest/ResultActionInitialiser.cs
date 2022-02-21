namespace XpressTest;

public static class ResultActionInitialiser<TSut>
    where TSut : class
{
    public static ISimpleAsserter<TResult> Initialise<TResult>(Func<TSut, TResult> func)
    {
        var actionExecutor = new SimpleResultActionExecutor<TSut, TResult>(
            func
            );

        var sutTesterComposer = new SimpleSutTesterComposer<TSut, TResult>(
            actionExecutor
        );

        var builder = new SimpleResultAsserter<TSut, TResult>(
            sutTesterComposer
        );

        return builder;
    }
}
