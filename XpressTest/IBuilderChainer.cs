namespace XpressTest;

public interface IBuilderChainer<TSut>
{
    IMockDependencySetupBuilder<TSut, TDependency> StartNewMockDependencyBuilder<TDependency>()
        where TDependency : class;
    
    IMockDependencySetupBuilder<TSut, TDependency> StartNewMockDependencyBuilder<TDependency>(
        string name
    )
        where TDependency : class;
    
    IMockDependencySetupBuilder<TSut, TDependency> StartNewExistingMockDependencyBuilder<TDependency>()
        where TDependency : class;
    
    IDependencyBuilder<TSut> StartNewExistingObjectDependencyBuilder<TObject>();
    
    IDependencyBuilder<TSut> StartNewObjectDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string name
    );

    IDependencyBuilder<TSut> StartNewExistingObjectDependencyBuilder<TObject>(
        string objectName
    );
    
    IDependencyBuilder<TSut> StartNewObjectDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
    );
    
    IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<TSut, TResult> func
    );
    
    IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
    );
    
    IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    );
    
    IVoidAsserter<TSut> StartVoidAsserter(
        Action<TSut> action
    );
    
    IVoidAsserter<TSut> StartVoidAsserter(
        Action<ISutArrangement<TSut>> action
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> StartAsyncResultAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> StartAsyncResultAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );
    
    ISutPropertyTargeter<TSut> StartSutAsserter();
}