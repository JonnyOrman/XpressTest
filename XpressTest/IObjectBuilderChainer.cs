namespace XpressTest;

public interface IObjectBuilderChainer<TSut>
{
    IResultAsserter<TSut, TResult> ComposeResultAsserter<TResult>(Func<IAction<TSut>, TResult> resultFunc);
    
    IVoidAsserter<TSut> ComposeVoidAsserter(System.Action<IAction<TSut>> action);
    
    IExistingObjectBuilder<TSut> ComposeExistingObjectBuilder<TExistingObject>() where TExistingObject : class;
    
    IExistingObjectBuilder<TSut> ComposeExistingObjectBuilder<TExistingObject>(string existingObjectName);
    
    IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TDependency>(TDependency dependency);
    
    IMockDependencyBuilder<TSut, TMock> ComposeMockDependencyBuilder<TMock>() where TMock : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder2<TNewDependency>() where TNewDependency : class;
    
    IMockObjectBuilder<TSut, TNewObject> ComposeMockObjectBuilder<TNewObject>() where TNewObject : class;
    
    IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(TNewObject newObject);
    
    IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(TNewObject newObject, string newObjectName);
    
    IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(Func<IArrangement, TNewObject> newObjectFunc);
    
    IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(Func<IArrangement, TNewObject> newObjectFunc, string newObjectName);
}