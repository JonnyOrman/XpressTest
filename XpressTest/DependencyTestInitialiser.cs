namespace XpressTest;

public static class DependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(TDependency dependency)
        where TDependency : class
    {
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new DependencyBuilder<TSut, TDependency>(
            dependency,
            testComposer
        );
    }
}
