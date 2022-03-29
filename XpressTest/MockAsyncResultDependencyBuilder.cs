using System.Linq.Expressions;
using Moq;

namespace XpressTest;

public class MockAsyncResultDependencyBuilder<TSut, TDependency, TResult>
:
    IMockResultDependencyBuilder<TSut, TDependency, TResult>
where TDependency : class
{
    private readonly Expression<Func<TDependency, Task<TResult>>> _expression;
    private readonly Mock<TDependency> _dependencyMock;
    private readonly IMockDependencyBuilder<TSut, TDependency> _mockDependencyBuilder;
    private readonly IArrangement _arrangement;

    public MockAsyncResultDependencyBuilder(
        Expression<Func<TDependency, Task<TResult>>> expression,
        Mock<TDependency> dependencyMock,
        IMockDependencyBuilder<TSut, TDependency> mockDependencyBuilder,
        IArrangement arrangement
        )
    {
        _expression = expression;
        _dependencyMock = dependencyMock;
        _mockDependencyBuilder = mockDependencyBuilder;
        _arrangement = arrangement;
    }
    
    public IMockDependencyBuilder<TSut, TDependency> AndReturns(
        TResult expectedResult
        )
    {
        _dependencyMock.Setup(_expression).ReturnsAsync(expectedResult);

        return _mockDependencyBuilder;
    }

    public IMockDependencyBuilder<TSut, TDependency> AndReturns(
        Func<IArrangement, TResult> resultFunc
        )
    {
        var expectedResult = resultFunc.Invoke(_arrangement);

        _dependencyMock.Setup(_expression).ReturnsAsync(expectedResult);

        return _mockDependencyBuilder;
    }

    public IMockDependencyBuilder<TSut, TDependency> AndReturns<TReturn>()
        where TReturn : class, TResult
    {
        throw new NotImplementedException();
    }
}