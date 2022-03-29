namespace XpressTest;

public interface INamedObjectBuilderChainer<TSut>
{
    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;
    
    IMockDependencyBuilder<TSut, TDependency> StartExistingMockDependencyBuilder<TDependency>()
        where TDependency : class;
    
    INamedObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        TNewDependency newObject,
        string name
        );
    
    INamedObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        Func<IArrangement, TNewDependency> func,
        string name
    );

    IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
    );
    
    IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        Func<IArrangement, TNewObject> func
    );
    
    IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class;

    IExistingObjectBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
        );
    
    IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<IAction<TSut>, TResult> func
    );
    
    IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<IArrangement, Func<TSut, TResult>> func
    );
    
    IVoidAsserter<TSut> Compose(
        System.Action<IAction<TSut>> action
        );
}