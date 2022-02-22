namespace XpressTest;

public static class SimpleVoidActionExecutorInitialiser<TSut>
{
    public static ISimpleVoidActionExecutor Initialise(System.Action<TSut> action)
    {
        var sut = Activator.CreateInstance<TSut>();

        return new SimpleVoidActionExecutor<TSut>(
            sut,
            action
        );
    }
}
