namespace XpressTest;

public static class SimpleResultAsserterInitialiser<TSut>
{
    public static ISimpleResultAsserter<TResult> Initialise<TResult>(Func<TSut, TResult> func)
    {
        var sut = Activator.CreateInstance<TSut>();

        var resultProvider = new ResultProvider<TSut, TResult>(
            sut,
            func
        );

        var arrangement = ArrangementInitialiser.Initialise();

        Action action = () => resultProvider.Get();

        var exceptionAsserter = new ExceptionAsserter(action);

        return new SimpleResultAsserter<TSut, TResult>(
            sut,
            arrangement,
            () => resultProvider.Get(),
            exceptionAsserter);
    }
}