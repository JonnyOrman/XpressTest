namespace XpressTest;

public static class ExceptionAsserterInitialiser<TSut>
{
    public static IExceptionAsserter Initialise(System.Action<TSut> action)
    {
        var simpleVoidActionExecutor = SimpleVoidActionExecutorInitialiser<TSut>.Initialise(action);

        return new ExceptionAsserter(() => simpleVoidActionExecutor.Execute());
    }

    public static IExceptionAsserter Initialise<TResult>(Func<TSut, TResult> func)
    {
        var simpleVoidActionExecutor = ResultProviderInitialiser<TSut, TResult>.Initialise(func);

        return new ExceptionAsserter(() => simpleVoidActionExecutor.Get());
    }
}
