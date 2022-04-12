using System.Linq.Expressions;

namespace XpressTest;

public interface IDependencyBuilderChainer<TSut>
:
    IBuilderChainer<TSut>
    where TSut : class

{
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
}