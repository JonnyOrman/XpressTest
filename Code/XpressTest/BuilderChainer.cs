namespace XpressTest;

public class BuilderChainer<TSut>
:
    IBuilderChainer<TSut>
where TSut : class
{
    protected readonly ITestBuilderContainer<TSut> TestBuilderContainer;

    protected BuilderChainer(
        ITestBuilderContainer<TSut> testBuilderContainer
        )
    {
        TestBuilderContainer = testBuilderContainer;
    }

    public IMockDependencySetupBuilder<TSut, TDependency> StartNewMockDependencyBuilder<TDependency>()
        where TDependency : class
    {
        return TestBuilderContainer.DependencyBuilderCreator.CreateMockDependencyBuilder<TDependency>();
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>(
        string name
    )
        where TNewDependency : class
    {
        return TestBuilderContainer.DependencyBuilderCreator.CreateMockDependencyBuilder<TNewDependency>(
            name
        );
    }

    public IMockDependencySetupBuilder<TSut, TMock> StartNewExistingMockDependencyBuilder<TMock>()
        where TMock : class
    {
        return TestBuilderContainer.DependencyBuilderCreator.CreateExistingMockDependencyBuilder<TMock>();
    }

    public IDependencyBuilder<TSut> StartNewObjectDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName
    )
    {
        return TestBuilderContainer.DependencyBuilderCreator.CreateObjectDependencyBuilder(
            newDependency,
            newDependencyName
        );
    }

    public IDependencyBuilder<TSut> StartNewExistingObjectDependencyBuilder<TNewDependency>()
    {
        return TestBuilderContainer.DependencyBuilderCreator.Create<TNewDependency>();
    }

    public IDependencyBuilder<TSut> StartNewExistingObjectDependencyBuilder<TObject>(
        string objectName
    )
    {
        return TestBuilderContainer.DependencyBuilderCreator.Create<TObject>(
            objectName
        );
    }

    public IDependencyBuilder<TSut> StartNewObjectDependencyBuilder<TDependency>(TDependency dependency)
    {
        return TestBuilderContainer.DependencyBuilderCreator.CreateObjectDependencyBuilder(dependency);
    }

    public IVoidAsserter<TSut> StartVoidAsserter(
        Action<ISutArrangement<TSut>> action
    )
    {
        return TestBuilderContainer.AsserterCreator.CreateVoidAsserter(
            action
        );
    }

    public IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<TSut, TResult> func
    )
    {
        return TestBuilderContainer.AsserterCreator.CreateResultAsserter(
            func
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> StartAsyncResultAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    )
    {
        return await TestBuilderContainer.AsserterCreator.CreateAsyncResultAsserter(
            func
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> StartAsyncResultAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    )
    {
        return await TestBuilderContainer.AsserterCreator.CreateAsyncResultAsserter(
            func
        );
    }

    public IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    )
    {
        return TestBuilderContainer.AsserterCreator.CreateResultAsserter(
            func
        );
    }

    public ISutPropertyTargeter<TSut> StartSutAsserter()
    {
        return TestBuilderContainer.AsserterCreator.CreateSutAsserter();
    }

    public IVoidAsserter<TSut> StartVoidAsserter(
        Action<TSut> func
    )
    {
        return TestBuilderContainer.AsserterCreator.CreateVoidAsserter(
            func
        );
    }

    public IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
        )
    {
        return TestBuilderContainer.AsserterCreator.CreateResultAsserter(
            func
        );
    }
}