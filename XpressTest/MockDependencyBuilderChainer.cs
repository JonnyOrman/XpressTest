namespace XpressTest;

public class MockDependencyBuilderChainer<TSut>
    :
        IMockDependencyBuilderChainer<TSut>
where TSut : class
{
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private readonly INamedDependencyBuilderCreator<TSut> _namedDependencyBuilderCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private IValueDependencyBuilderCreator<TSut> _valueDependencyBuilderCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;

    public MockDependencyBuilderChainer(
        IAsserterCreator<TSut> asserterCreator,
        INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IValueDependencyBuilderCreator<TSut> valueDependencyBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator
        )
    {
        _asserterCreator = asserterCreator;
        _namedDependencyBuilderCreator = namedDependencyBuilderCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _valueDependencyBuilderCreator = valueDependencyBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName
        )
    where TNewDependency : class
    {
        return _namedDependencyBuilderCreator.Create(
            newDependency,
            newDependencyName
        );
    }

    public IExistingObjectBuilder<TSut> ComposeDependencyBuilder<TNewDependency>()
    {
        return _objectBuilderCreator.Create<TNewDependency>();
    }

    public IVoidAsserter<TSut> ComposeMockAsserter(
        System.Action<TSut> action
        )
    {
        return _asserterCreator.CreateVoidAsserter(
            action
        );
    }

    public IVoidAsserter<TSut> ComposeMockAsserter(
        System.Action<IAction<TSut>> action
        )
    {
        return _asserterCreator.CreateVoidAsserter(
            action
            );
    }

    public IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult>(
        Func<IAction<TSut>, TResult> func
        )
    {
        return _asserterCreator.CreateResultAsserter(
            func
        );
    }

    public IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult>(
        Func<TSut, TResult> func
        )
    {
        return _asserterCreator.CreateResultAsserter(
            func
            );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }

    public IExistingObjectBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
        )
    {
        return _objectBuilderCreator.Create<TObject>(
            objectName
            );
    }

    public IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>(
        TNewDependency newDependency
        )
        where TObject : class
    {
        return _valueDependencyBuilderCreator.Create(newDependency);
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeNamedMockDependencyBuilder<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>(
            name
            );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
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

    public void Set(MockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public void Set(ValueDependencyBuilderCreator<TSut> valueDependencyBuilderCreator)
    {
        _valueDependencyBuilderCreator = valueDependencyBuilderCreator;
    }
    
    public void Set(IObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
}