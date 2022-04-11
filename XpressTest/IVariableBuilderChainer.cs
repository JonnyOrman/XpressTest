namespace XpressTest;

public interface IVariableBuilderChainer<TSut>
{
    IMockDependencySetupBuilder<TSut, TObject> StartNewMockDependencyBuilder<TObject>()
        where TObject : class;
    
    IMockDependencySetupBuilder<TSut, TDependency> StartExistingMockDependencyBuilder<TDependency>()
        where TDependency : class;
    
    IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        TNewDependency newObject,
        string name
        );
    
    IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> func,
        string name
    );

    IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
    );
    
    IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        Func<IReadArrangement, TNewObject> func
    );
    
    IMockSetupBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class;

    IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>();
    
    IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
        );
    
    IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<TSut, TResult> func
    );
    
    IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    );
    
    IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
    );
    
    IVoidAsserter<TSut> Compose(
        Action<TSut> action
    );
    
    IVoidAsserter<TSut> Compose(
        Action<ISutArrangement<TSut>> action
        );

    IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
        );
    
    IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    );
    
    IDependencyBuilder<TSut> StartNewNamedDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string name
        );

    IMockDependencySetupBuilder<TSut, TNewDependency> StartNewNamedMockDependencyBuilder<TNewDependency>(
        string name
        )
        where TNewDependency : class;
    
    IMockSetupBuilder<TSut, TNewObject> StartNewNamedMockObjectBuilder<TNewObject>(
        string name
        )
        where TNewObject : class;
    
    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    );
    
    ISutPropertyTargeter<TSut> StartSutAsserter();
}