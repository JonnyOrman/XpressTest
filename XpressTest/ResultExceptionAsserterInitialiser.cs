namespace XpressTest;

public static class ResultExceptionAsserterInitialiser<TSut>
{
    public static IExceptionAsserter Initialise<TResult>(Func<TSut, TResult> func)
    {
        var simpleVoidActionExecutor = ResultProviderInitialiser<TSut, TResult>.Initialise(func);

        return new ExceptionAsserter(() => simpleVoidActionExecutor.Get());
    }
}