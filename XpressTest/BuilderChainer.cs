namespace XpressTest;

public class BuilderChainer<TSut>
:
    IBuilderChainer<TSut>
where TSut : class
{
    protected readonly ITestBuilderContainer<TSut> _testBuilderContainer;
    
    public BuilderChainer(
        ITestBuilderContainer<TSut> testBuilderContainer
        )
    {
        _testBuilderContainer = testBuilderContainer;
    }
    
    public IMockDependencySetupBuilder<TSut, TDependency> StartNewMockDependencyBuilder<TDependency>()
        where TDependency : class
    {
        return _testBuilderContainer.DependencyBuilderCreator.CreateMockDependencyBuilder<TDependency>();
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> StartNewNamedMockDependencyBuilder<TNewDependency>(
        string name
    )
        where TNewDependency : class
    {
        return _testBuilderContainer.DependencyBuilderCreator.CreateNamedMockDependencyBuilder<TNewDependency>(
            name
        );
    }

    public IMockDependencySetupBuilder<TSut, TMock> StartExistingMockDependencyBuilder<TMock>()
        where TMock : class
    {
        return _testBuilderContainer.DependencyBuilderCreator.CreateExistingMockDependencyBuilder<TMock>();
    }

    public IDependencyBuilder<TSut> StartNewNamedDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName
    )
    {
        return _testBuilderContainer.DependencyBuilderCreator.CreateNamedDependencyBuilder(
            newDependency,
            newDependencyName
        );
    }

    public IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TNewDependency>()
    {
        return _testBuilderContainer.DependencyBuilderCreator.Create<TNewDependency>();
    }

    public IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
    )
    {
        return _testBuilderContainer.DependencyBuilderCreator.Create<TObject>(
            objectName
        );
    }

    public IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TDependency>(TDependency dependency)
    {
        return _testBuilderContainer.DependencyBuilderCreator.CreateObjectDependencyBuilder(dependency);
    }

    public IVoidAsserter<TSut> ComposeAsserter(
        Action<ISutArrangement<TSut>> action
    )
    {
        return _testBuilderContainer.AsserterCreator.CreateVoidAsserter(
            action
        );
    }

    public IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(
        Func<TSut, TResult> func
    )
    {
        return _testBuilderContainer.AsserterCreator.CreateResultAsserter(
            func
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    )
    {
        return await _testBuilderContainer.AsserterCreator.CreateAsyncResultAsserter(
            func
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    )
    {
        return await _testBuilderContainer.AsserterCreator.CreateAsyncResultAsserter(
            func
        );
    }

    public IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    )
    {
        return _testBuilderContainer.AsserterCreator.CreateResultAsserter(
            func
        );
    }

    public ISutPropertyTargeter<TSut> StartSutAsserter()
    {
        return _testBuilderContainer.AsserterCreator.CreateSutAsserter();
    }

    public IVoidAsserter<TSut> ComposeAsserter(
        Action<TSut> func
    )
    {
        return _testBuilderContainer.AsserterCreator.CreateVoidAsserter(
            func
        );
    }
    
    public IResultAsserter<TSut, TResult> ComposeAsserter<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func)
    {
        return _testBuilderContainer.AsserterCreator.CreateResultAsserter(
            func
        );
    }
}