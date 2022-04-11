namespace XpressTest;

public interface IWithNamedDependencyBuilder<TSut>
{
    IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
    );
}