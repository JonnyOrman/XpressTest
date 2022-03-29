namespace XpressTest;

public interface INamedMockDependencyBuilderCreator<TSut>
{
    INamedMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        string dependencyName
        )
        where TDependency : class;
}