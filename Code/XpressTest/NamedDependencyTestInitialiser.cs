namespace XpressTest;

public static class NamedDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(
        TDependency dependency,
        string name
        )
    {
        var container = ContainerComposer<TSut>.Compose();

        return container.NamedDependencyBuilderCreator.Create(
            dependency,
            name
        );
    }
}