namespace XpressTest;

public static class VoidActionInitialiser<TSut>
{
    public static ISimpleAsserter Initialise(System.Action<TSut> action)
    {
        var exceptionAsserter = ExceptionAsserterInitialiser<TSut>.Initialise(action);

        return new SimpleVoidAsserter(
            exceptionAsserter
        );
    }
}