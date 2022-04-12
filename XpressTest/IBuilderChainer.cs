namespace XpressTest;

public interface IBuilderChainer<TSut>
{
    IMockDependencySetupBuilder<TSut, TDependency> StartNewMockDependencyBuilder<TDependency>()
        where TDependency : class;
    
    IMockDependencySetupBuilder<TSut, TDependency> StartNewNamedMockDependencyBuilder<TDependency>(
        string name
    )
        where TDependency : class;
    
    IMockDependencySetupBuilder<TSut, TDependency> StartExistingMockDependencyBuilder<TDependency>()
        where TDependency : class;
    
    IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>();
    
    IDependencyBuilder<TSut> StartNewNamedDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string name
    );

    IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
    );
    
    IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
    );
    
    IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(
        Func<TSut, TResult> func
    );
    
    IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
    );
    
    IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    );
    
    IVoidAsserter<TSut> ComposeAsserter(
        Action<TSut> action
    );
    
    IVoidAsserter<TSut> ComposeAsserter(
        Action<ISutArrangement<TSut>> action
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );
    
    ISutPropertyTargeter<TSut> StartSutAsserter();
}