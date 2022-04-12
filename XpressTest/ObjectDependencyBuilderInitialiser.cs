namespace XpressTest;

public static class ObjectDependencyBuilderInitialiser<TSut>
where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(TDependency dependency)
    {
        var container = ContainerComposer<TSut>.Compose();

        return container.ObjectDependencyBuilderCreator.Create(dependency);
    }
}