namespace XpressTest;

public interface IMockObjectBuilderChainer<TSut>
{
    IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>(
        Func<IArrangement, TNewDependency> newDependencyFunc
        )
        where TObject : class;

    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> StartExistingMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;

    IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class;

    IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(TNewObject newObject);
    
    IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(Func<IArrangement, TNewObject> func);
    
    INamedObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewObject>(
        TNewObject newObject,
        string name
        );

    IExistingObjectBuilder<TSut> StartNewExistingObjectBuilder<TNamedObject>(
        string objectName
        );
}