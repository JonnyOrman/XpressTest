namespace XpressTest;

public static class VoidExceptionAsserterInitialiser<TSut>
{
    public static IExceptionAsserter Initialise(Action<TSut> action)
    {
        var simpleVoidActionExecutor = SimpleVoidActionExecutorInitialiser<TSut>.Initialise(action);

        return new ExceptionAsserter(() => simpleVoidActionExecutor.Execute());
    }
}
