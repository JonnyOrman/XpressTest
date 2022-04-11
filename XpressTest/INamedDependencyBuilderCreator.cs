namespace XpressTest;

public interface INamedDependencyBuilderCreator<TSut>
where TSut : class
{
    IDependencyBuilder<TSut> Create<TNewDependency>(
        TNewDependency newDependency,
        string name
        );
}