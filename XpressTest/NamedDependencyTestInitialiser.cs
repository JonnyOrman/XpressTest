namespace XpressTest;

public static class NamedDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(
        TDependency dependency,
        string name
        )
        where TDependency : class
    {
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new NamedDependencyBuilder<TSut, TDependency>(
            dependency,
            name,
            testComposer
        );
    }
}