namespace XpressTest;

public interface IDependencyBuilderChainer<TSut>
{
     IValueDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
    );
    
    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;

    ISutAsserter<TSut> ComposeAsserter();
    
    IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(
        Func<IAction<TSut>, TResult> func
        );
    
    IVoidAsserter<TSut> ComposeAsserter(
        System.Action<TSut> action
    );
    
    IVoidAsserter<TSut> ComposeAsserter(
        System.Action<IAction<TSut>> func
    );
}