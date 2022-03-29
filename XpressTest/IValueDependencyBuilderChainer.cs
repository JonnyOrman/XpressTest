namespace XpressTest;

public interface IValueDependencyBuilderChainer<TSut>
{
    ISutAsserter<TSut> StartSutAsserter();
    
    IVoidAsserter<TSut> StartVoidAsserter(
        System.Action<TSut> func
    );

    IMockDependencyBuilder<TSut, TMockDependency> StartMockDependencyBuilder<TMockDependency>()
        where TMockDependency : class;
    
    INamedMockDependencyBuilder<TSut, TDependency> StartNamedMockDependencyBuilder<TDependency>(
        string dependencyName
        )
        where TDependency : class;

    IValueDependencyBuilder<TSut> StartValueDependencyBuilder<TDependency>(TDependency dependency);
}