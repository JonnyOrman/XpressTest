namespace XpressTest;

public interface INamedMockDependencyBuilderCreator<TSut>
{
    IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>(
        string dependencyName
        )
        where TDependency : class;
}