namespace XpressTest;

public class ObjectBuilderChainer<TSut>
    :
        IObjectBuilderChainer<TSut>
where TSut : class
{
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private readonly IResultAsserterCreator<TSut> _resultAsserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private IValueDependencyBuilderCreator<TSut> _valueDependencyBuilderCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private IMockObjectBuilderCreator<TSut> _mockObjectBuilderCreator;

    public ObjectBuilderChainer(
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IResultAsserterCreator<TSut> resultAsserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IValueDependencyBuilderCreator<TSut> valueDependencyBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        IMockObjectBuilderCreator<TSut> mockObjectBuilderCreator
    )
    {
        _voidAsserterCreator = voidAsserterCreator;
        _resultAsserterCreator = resultAsserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _valueDependencyBuilderCreator = valueDependencyBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _mockObjectBuilderCreator = mockObjectBuilderCreator;
    }
    
    public IResultAsserter<TSut, TResult> ComposeResultAsserter<TResult>(
        Func<IAction<TSut>, TResult> resultFunc
        )
    {
        return _resultAsserterCreator.Create(
            resultFunc
        );
    }

    public IVoidAsserter<TSut> ComposeVoidAsserter(System.Action<IAction<TSut>> action)
    {
        return _voidAsserterCreator.Create(
            action
        );
    }

    public IExistingObjectBuilder<TSut> ComposeExistingObjectBuilder<TExistingObject>()
        where TExistingObject : class
    {
        return _objectBuilderCreator.Create<TExistingObject>();
    }

    public IExistingObjectBuilder<TSut> ComposeExistingObjectBuilder<TExistingObject>(
        string existingObjectName
        )
    {
        return _objectBuilderCreator.Create<TExistingObject>(
            existingObjectName
            );
    }

    public IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TDependency>(
        TDependency dependency
        )
    {
        return _valueDependencyBuilderCreator.Create(dependency);
    }

    public IMockDependencyBuilder<TSut, TMock> ComposeMockDependencyBuilder<TMock>()
        where TMock : class
    {
        return _mockDependencyBuilderCreator.Create<TMock>();
    }

    public IMockDependencyBuilder<TSut, TMock> ComposeMockDependencyBuilder2<TMock>()
        where TMock : class
    {
        return _mockDependencyBuilderCreator.CreateExisting<TMock>();
    }

    public IMockObjectBuilder<TSut, TNewObject> ComposeMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        return _mockObjectBuilderCreator.Create<TNewObject>();
    }

    public IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(TNewObject newObject)
    {
        return _objectBuilderCreator.Create(
            newObject
        );
    }

    public IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(TNewObject newObject, string newObjectName)
    {
        return _objectBuilderCreator.Create(
            newObject,
            newObjectName
        );
    }

    public IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(Func<IArrangement, TNewObject> newObjectFunc)
    {
        return _objectBuilderCreator.Create(
            newObjectFunc
        );
    }

    public IObjectBuilder<TSut> ComposeObjectBuilder<TNewObject>(Func<IArrangement, TNewObject> newObjectFunc, string newObjectName)
    {
        return _objectBuilderCreator.Create(
            newObjectFunc,
            newObjectName
            );
    }

    public void Set(ObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public void Set(IValueDependencyBuilderCreator<TSut> valueDependencyBuilderCreator)
    {
        _valueDependencyBuilderCreator = valueDependencyBuilderCreator;
    }
    
    public void Set(IMockObjectBuilderCreator<TSut> mockObjectBuilderCreator)
    {
        _mockObjectBuilderCreator = mockObjectBuilderCreator;
    }
}