namespace XpressTest;

public interface IMockTypeDependencyBuilderCreator<TSut>
    where TSut : class
{
    IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>()
        where TDependency : class;

    IMockDependencySetupBuilder<TSut, TDependency> CreateExisting<TDependency>()
        where TDependency : class;
}