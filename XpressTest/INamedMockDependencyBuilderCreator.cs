namespace XpressTest;

public interface INamedMockDependencyBuilderCreator<TSut>
{
    IMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        string dependencyName
        )
        where TDependency : class;
}