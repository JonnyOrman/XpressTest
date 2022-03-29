namespace XpressTest;

public static class SimpleResultAsserterInitialiser<TSut>
{
    public static ISimpleResultAsserter<TResult> Initialise<TResult>(Func<TSut, TResult> func)
    {
        var sutComposer = SutComposerInitialiser<TSut>.Initialise();

        var sut = sutComposer.Compose();

        var resultProvider = ResultProviderInitialiser<TSut, TResult>.Initialise(func);

        var arrangement = ArrangementInitialiser.Initialise();

        return new SimpleResultAsserter<TSut, TResult>(
            sut,
            arrangement,
            () => resultProvider.Get());
    }
}