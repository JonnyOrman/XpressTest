namespace XpressTest;

public static class DependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(TDependency dependency)
    {
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new DependencyBuilder<TSut, TDependency>(
            dependency,
            testComposer
        );
    }
}
