namespace XpressTest;

public interface IWithIDependencyBuilder<TSut>
{
    IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
    );
}