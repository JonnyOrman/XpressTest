namespace XpressTest;

public interface INamedDependencyBuilderCreator<TSut>
where TSut : class
{
    IDependencyBuilder<TSut> Create<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class;

    void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator);
}