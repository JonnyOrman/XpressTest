namespace XpressTest;

public interface IVariableBuilderChainer<TSut>
:
    IBuilderChainer<TSut>
{
    IDependencyBuilder<TSut> StartExistingObjectDependencyBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    );

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

    IMockSetupBuilder<TSut, TNewObject> StartNewNamedMockObjectBuilder<TNewObject>(
        string name
        )
        where TNewObject : class;
}