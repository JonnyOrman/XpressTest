using System.Linq.Expressions;

namespace XpressTest;

public class DependencyBuilderChainer<TSut>
    :
        IDependencyBuilderChainer<TSut>
    where TSut : class
{
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private readonly IArrangement _arrangement;
    private readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public DependencyBuilderChainer(
        IAsserterCreator<TSut> asserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IArrangement arrangement,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator,
        ISutAsserterCreator<TSut> sutAsserterCreator
    )
    {
        _asserterCreator = asserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _arrangement = arrangement;
        _dependencyBuilderCreator = dependencyBuilderCreator;
        _sutAsserterCreator = sutAsserterCreator;
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName
    )
    {
        return _dependencyBuilderCreator.CreateNamedDependencyBuilder(
            newDependency,
            newDependencyName
        );
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>()
    {
        return _objectBuilderCreator.Create<TNewDependency>();
    }

    public IVoidAsserter<TSut> ComposeMockAsserter(
        Action<ISutArrangement<TSut>> action
    )
    {
        return _asserterCreator.CreateVoidAsserter(
            action
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

    public IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
    )
    {
        return _objectBuilderCreator.Create<TObject>(
            objectName
        );
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

    public IMockDependencySetupBuilder<TSut, TMock> StartExistingMockDependencyBuilder<TMock>()
        where TMock : class
    {
        return _dependencyBuilderCreator.CreateExistingMockDependencyBuilder<TMock>();
    }

    public IMockResultDependencyBuilder<TSut, TResult> StartMockResultDependencyBuilder<TDependency, TResult>(
        Expression<Func<TDependency, TResult>> expression,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder
    )
        where TDependency : class
    {
        return new MockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            mock,
            mockDependencyBuilder,
            _arrangement
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TResult> StartMockAsyncResultDependencyBuilder<TDependency, TResult>(
        Func<IReadArrangement, Expression<Func<TDependency, Task<TResult>>>> func,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder
    )
        where TDependency : class
    {
        var expression = func.Invoke(_arrangement);

        return new MockAsyncResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            mock,
            mockDependencyBuilder,
            _arrangement
        );
    }

    public IMockAsyncResultDependencyBuilder<TSut, TResult> StartMockAsyncResultDependencyBuilder<TDependency, TResult>(
        Expression<Func<TDependency, Task<TResult>>> expression,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder
    )
        where TDependency : class
    {
        return new MockAsyncResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            mock,
            mockDependencyBuilder,
            _arrangement
        );
    }

    public void Set(IObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }

    public IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    )
    {
        return _asserterCreator.CreateResultAsserter(
            func
        );
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> StartNamedMockDependencyBuilder<TNewDependency>(
        string name
    )
        where TNewDependency : class
    {
        return _dependencyBuilderCreator.CreateNamedMockDependencyBuilder<TNewDependency>(
            name
        );
    }
    
    public ISutPropertyTargeter<TSut> StartSutAsserter()
    {
        return _sutAsserterCreator.Create();
    }

    public IVoidAsserter<TSut> StartVoidAsserter(
        Action<TSut> func
    )
    {
        return _asserterCreator.CreateVoidAsserter(
            func
        );
    }
    
    public IMockDependencySetupBuilder<TSut, TDependency> StartMockDependencyBuilder<TDependency>()
        where TDependency : class
    {
        return _dependencyBuilderCreator.CreateMockDependencyBuilder<TDependency>();
    }
    
    public IDependencyBuilder<TSut> StartValueDependencyBuilder<TDependency>(TDependency dependency)
    {
        return _dependencyBuilderCreator.CreateObjectDependencyBuilder(dependency);
    }
}