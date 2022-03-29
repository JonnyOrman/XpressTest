namespace XpressTest;

public interface INamedDependencyBuilderCreator<TSut>
where TSut : class
{
    INamedDependencyBuilder<TSut> Create<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class;
}