namespace XpressTest;

public static class ResultActionInitialiser<TSut>
{
    public static ISimpleAsserter Initialise<TResult>(Func<TSut, TResult> func)
    {
        var resultProvider = new ResultProvider<TSut, TResult>(func);

        return new SimpleResultAsserter<TResult>(
            resultProvider
        );
    }
}
