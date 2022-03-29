namespace XpressTest;

public interface IMockDependencyBuilderChainer<TSut>
{
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName
    )
        where TNewDependency : class;

    IExistingObjectBuilder<TSut> ComposeDependencyBuilder<TNewDependency>();

    IVoidAsserter<TSut> ComposeMockAsserter(
        System.Action<TSut> action
    );
    
    IVoidAsserter<TSut> ComposeMockAsserter(
        System.Action<IAction<TSut>> func
    );
    
    IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult>(
        Func<IAction<TSut>, TResult> func
    );
    
    IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult>(
        Func<TSut, TResult> func
    );
    
    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;

    IExistingObjectBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
        );
    
    IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>(
        TNewDependency newDependency
    )
        where TObject : class;

    IMockDependencyBuilder<TSut, TNewDependency> ComposeNamedMockDependencyBuilder<TNewDependency>(
        string name
        )
        where TNewDependency : class;
    
    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    );
}