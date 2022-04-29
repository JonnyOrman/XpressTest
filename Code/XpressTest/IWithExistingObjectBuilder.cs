namespace XpressTest;

public interface IWithExistingObjectBuilder<TSut>
{
    IDependencyBuilder<TSut> WithThe<TNewDependency>();
}