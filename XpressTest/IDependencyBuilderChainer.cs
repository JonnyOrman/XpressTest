namespace XpressTest;

public interface IDependencyBuilderChainer<TSut>
{
     IValueDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
    );
    
    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;

    ISutAsserter<TSut> ComposeAsserter();
    
    IVoidAsserter<TSut> ComposeAsserter(
        System.Action<TSut> action
    );
}