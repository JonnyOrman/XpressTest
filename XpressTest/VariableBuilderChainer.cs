namespace XpressTest;

public class VariableBuilderChainer<TSut>
    :
        IVariableBuilderChainer<TSut>
where TSut : class
{
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private IMockSetupBuilderCreator<TSut> _mockObjectBuilderGenerator;
    protected readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;
    private readonly INamedMockSetupBuilderCreator<TSut> _namedMockObjectBuilderGenerator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public VariableBuilderChainer(
        IAsserterCreator<TSut> asserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IMockSetupBuilderCreator<TSut> mockObjectBuilderGenerator,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator,
        INamedMockSetupBuilderCreator<TSut> namedMockObjectBuilderGenerator,
        ISutAsserterCreator<TSut> sutAsserterCreator
        )
    {
        _asserterCreator = asserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _mockObjectBuilderGenerator = mockObjectBuilderGenerator;
        _dependencyBuilderCreator = dependencyBuilderCreator;
        _namedMockObjectBuilderGenerator = namedMockObjectBuilderGenerator;
        _sutAsserterCreator = sutAsserterCreator;
    }
    
    public IMockDependencySetupBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _dependencyBuilderCreator.CreateMockDependencyBuilder<TNewDependency>();
    }

    public IMockDependencySetupBuilder<TSut, TDependency> StartExistingMockDependencyBuilder<TDependency>()
        where TDependency : class
    {
        return _dependencyBuilderCreator.CreateExistingMockDependencyBuilder<TDependency>();
    }

    public IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        TNewDependency newObject,
        string name
        )
    {
        return _objectBuilderCreator.Create(
            newObject,
            name
            );
    }

    public IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> func,
        string name
        )
    {
        return _objectBuilderCreator.Create(
            func,
            name
        );
    }

    public IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
        )
    {
        return _objectBuilderCreator.Create(
            newObject
        );
    }

    public IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        Func<IReadArrangement, TNewObject> func
        )
    {
        return _objectBuilderCreator.Create(
            func
        );
    }

    public IMockSetupBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        return _mockObjectBuilderGenerator.Create<TNewObject>();
    }

    public IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>()
    {
        return _objectBuilderCreator.Create<TObject>();
    }

    public IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
        )
    {
        return _objectBuilderCreator.Create<TObject>(
            objectName
        );
    }

    public IResultAsserter<TSut, TResult> Compose<TResult>(Func<TSut, TResult> func)
    {
        return _asserterCreator.CreateResultAsserter(
            func
        );
    }

    public IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
        )
    {
        return _asserterCreator.CreateResultAsserter(
            func
        );
    }

    public IResultAsserter<TSut, TResult> Compose<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func)
    {
        return _asserterCreator.CreateResultAsserter(
            func
        );
    }

    public IVoidAsserter<TSut> Compose(Action<TSut> action)
    {
        return _asserterCreator.CreateVoidAsserter(
            action
        );
    }

    public IVoidAsserter<TSut> Compose(
        Action<ISutArrangement<TSut>> action
        )
    {
        return _asserterCreator.CreateVoidAsserter(
            action
        );
    }

    public IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
        )
    {
        return _dependencyBuilderCreator.CreateObjectDependencyBuilder(newDependency);
    }

    public IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    )
    {
        return _dependencyBuilderCreator.CreateObjectDependencyBuilder(
            newDependencyFunc
        );
    }

    public IDependencyBuilder<TSut> StartNewNamedDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
    {
        return _dependencyBuilderCreator.CreateNamedDependencyBuilder(
            newDependency,
            name
        );
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> StartNewNamedMockDependencyBuilder<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return _dependencyBuilderCreator.CreateNamedMockDependencyBuilder<TNewDependency>(name);
    }

    public IMockSetupBuilder<TSut, TNewObject> StartNewNamedMockObjectBuilder<TNewObject>(
        string name
        )
        where TNewObject : class
    {
        return _namedMockObjectBuilderGenerator.Create<TNewObject>(
            name
            );
    }

    public void Set(IObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public async Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    )
    {
        return await _asserterCreator.CreateAsyncResultAsserter(
            func
        );
    }
    
    public async Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    )
    {
        return await _asserterCreator.CreateAsyncResultAsserter(
            func
        );
    }
    
    public ISutPropertyTargeter<TSut> StartSutAsserter()
    {
        return _sutAsserterCreator.Create();
    }
}