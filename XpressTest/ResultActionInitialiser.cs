namespace XpressTest;

public static class ResultActionInitialiser<TSut>
{
    public static ISimpleAsserter Initialise<TResult>(Func<TSut, TResult> func)
    {
        var exceptionAsserter = ExceptionAsserterInitialiser<TSut>.Initialise(func);

        return new SimpleResultAsserter(
            exceptionAsserter
        );
    }
}
