using System.Linq.Expressions;

namespace XpressTest;

public interface IDependencyBuilderChainer<TSut>
    where TSut : class
{
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName
    );

    IDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>();

    IVoidAsserter<TSut> ComposeMockAsserter(
        Action<ISutArrangement<TSut>> func
    );

    IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult>(
        Func<TSut, TResult> func
    );

    IDependencyBuilder<TSut> StartNewExistingObjectBuilder<TObject>(
        string objectName
    );

    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );

    Task<IAsyncResultAsserter<TSut, TResult>> ComposeMockAsserter<TResult>(
        Func<TSut, Task<TResult>> func
    );

    IMockDependencySetupBuilder<TSut, TMock> StartExistingMockDependencyBuilder<TMock>()
        where TMock : class;

    IMockResultDependencyBuilder<TSut, TResult> StartMockResultDependencyBuilder<TDependency, TResult>(
        Expression<Func<TDependency, TResult>> expression,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder
    )
        where TDependency : class;

    IMockAsyncResultDependencyBuilder<TSut, TResult> StartMockAsyncResultDependencyBuilder<TDependency, TResult>(
        Func<IReadArrangement, Expression<Func<TDependency, Task<TResult>>>> func,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder)
        where TDependency : class;

    IMockAsyncResultDependencyBuilder<TSut, TResult> StartMockAsyncResultDependencyBuilder<TDependency, TResult>(
        Expression<Func<TDependency, Task<TResult>>> expression,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder)
        where TDependency : class;

    IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    );

    IMockDependencySetupBuilder<TSut, TDependency> StartNamedMockDependencyBuilder<TDependency>(
        string name
    )
        where TDependency : class;

    ISutPropertyTargeter<TSut> StartSutAsserter();

    IVoidAsserter<TSut> StartVoidAsserter(
        Action<TSut> func
    );

    IMockDependencySetupBuilder<TSut, TMockDependency> StartMockDependencyBuilder<TMockDependency>()
        where TMockDependency : class;

    IDependencyBuilder<TSut> StartValueDependencyBuilder<TDependency>(TDependency dependency);
}