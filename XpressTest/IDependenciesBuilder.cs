namespace XpressTest;

public interface IDependenciesBuilder<TSut>
:
    IWithAMockBuilder<TSut>,
    IWithMockBuilder<TSut>,
    IWithExistingObjectBuilder<TSut>,
    IWithExistingNamedObjectBuilder<TSut>,
    IWithIDependencyBuilder<TSut>,
    IWithNamedDependencyBuilder<TSut>,
    IWithNamedMockDependencyBuilder<TSut>
{
}