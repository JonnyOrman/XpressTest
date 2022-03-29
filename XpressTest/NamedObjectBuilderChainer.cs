namespace XpressTest;

public class NamedObjectBuilderChainer<TSut>
    :
        INamedObjectBuilderChainer<TSut>
where TSut : class
{
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private readonly IResultAsserterCreator<TSut> _resultAsserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private readonly IMockObjectBuilderCreator<TSut> _mockObjectBuilderCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;

    public NamedObjectBuilderChainer(
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IResultAsserterCreator<TSut> resultAsserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IMockObjectBuilderCreator<TSut> mockObjectBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator
        )
    {
        _voidAsserterCreator = voidAsserterCreator;
        _resultAsserterCreator = resultAsserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _mockObjectBuilderCreator = mockObjectBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }

    public IMockDependencyBuilder<TSut, TDependency> StartExistingMockDependencyBuilder<TDependency>()
        where TDependency : class
    {
        return _mockDependencyBuilderCreator.CreateExisting<TDependency>();
    }

    public IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        TNewDependency newObject,
        string name
        )
    {
        return _objectBuilderCreator.Create(
            newObject,
            name
            );
    }

    public IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        Func<IArrangement, TNewDependency> func,
        string name
        )
    {
        return _objectBuilderCreator.Create(
            func,
            name
        );
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

    public IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        return _mockObjectBuilderCreator.Create<TNewObject>();
    }

    public IExistingObjectBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
        )
    {
        return _objectBuilderCreator.Create<TObject>(
            objectName
        );
    }

    public IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<IAction<TSut>, TResult> func
        )
    {
        return _resultAsserterCreator.Create(
            func
        );
    }

    public IVoidAsserter<TSut> Compose(
        System.Action<IAction<TSut>> action
        )
    {
        return _voidAsserterCreator.Create(
            action
        );
    }

    public void Set(MockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public void Set(IObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
}