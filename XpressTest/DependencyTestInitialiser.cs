namespace XpressTest;

public static class DependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(TDependency dependency)
    {
        var arrangement = ArrangementInitialiser.Initialise();

        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        var builder = new DependencyBuilder<TSut, TDependency>(
            dependency,
            arrangement,
            testComposer
        );

        return builder;
    }
}
