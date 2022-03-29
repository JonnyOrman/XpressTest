namespace XpressTest;

public interface IMockDependencyBuilderCreator<TSut>
    where TSut : class
{
    IMockDependencyBuilder<TSut, TDependency> Create<TDependency>()
        where TDependency : class;
    
    INamedMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        string name
        )
        where TDependency : class;

    IMockDependencyBuilder<TSut, TDependency> CreateExisting<TDependency>()
        where TDependency : class;
}