using System.Linq.Expressions;

namespace XpressTest;

public class DependencyBuilderChainer<TSut>
    :
        BuilderChainer<TSut>,
        IDependencyBuilderChainer<TSut>
    where TSut : class
{
    private readonly IArrangement _arrangement;

    public DependencyBuilderChainer(
        IArrangement arrangement,
        ITestBuilderContainer<TSut> testBuilderContainer
    )
    :
    base(
        testBuilderContainer
        )
    {
        _arrangement = arrangement;
    }

    public IMockResultBuilder<TResult, IDependencyBuilder<TSut>> StartMockResultDependencyBuilder<TDependency, TResult>(
        Expression<Func<TDependency, TResult>> expression,
        IMock<TDependency> mock,
        IDependencyBuilder<TSut> mockDependencyBuilder
    )
        where TDependency : class
    {
        return new MockResultBuilder<TDependency, TResult, IDependencyBuilder<TSut>>(
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

        return StartMockAsyncResultDependencyBuilder(
            expression,
            mock,
            mockDependencyBuilder
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
}