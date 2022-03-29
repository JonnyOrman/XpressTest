namespace XpressTest;

public class MockObjectBuilderChainer<TSut>
    :
        IMockObjectBuilderChainer<TSut>
where TSut : class
{
    private readonly IValueDependencyBuilderCreator<TSut> _valueDependencyBuilderCreator;
    private readonly IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private readonly IMockObjectBuilderCreator<TSut> _mockObjectBuilderCreator;
    private readonly IObjectBuilderCreator<TSut> _objectBuilderCreator;

    public MockObjectBuilderChainer(
        IValueDependencyBuilderCreator<TSut> valueDependencyBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        IMockObjectBuilderCreator<TSut> mockObjectBuilderCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator
        )
    {
        _valueDependencyBuilderCreator = valueDependencyBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _mockObjectBuilderCreator = mockObjectBuilderCreator;
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>(
        Func<IArrangement, TNewDependency> newDependencyFunc
        )
        where TObject : class
    {
        return _valueDependencyBuilderCreator.Create(
            newDependencyFunc
            );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartExistingMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.CreateExisting<TNewDependency>();
    }

    public IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        return _mockObjectBuilderCreator.Create<TNewObject>();
    }

    public IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
        )
    {
        return _objectBuilderCreator.Create(
            newObject
            );
    }

    public IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        Func<IArrangement, TNewObject> func
        )
    {
        return _objectBuilderCreator.Create(
            func
        );
    }

    public IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewObject>(
        TNewObject newObject,
        string name
        )
    {
        return _objectBuilderCreator.Create(
            newObject,
            name
        );
    }

    public IExistingObjectBuilder<TSut> StartNewExistingObjectBuilder<TNamedObject>(
        string objectName
        )
    {
        return _objectBuilderCreator.Create<TNamedObject>(
            objectName
        );
    }
}