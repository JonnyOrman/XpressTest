using System.Linq.Expressions;
using Moq;

namespace XpressTest;

public class MockAsyncResultDependencyBuilder<TSut, TDependency, TResult>
:
    IMockAsyncResultDependencyBuilder<TSut, TResult>
where TDependency : class
{
    private readonly Expression<Func<TDependency, Task<TResult>>> _expression;
    private readonly IMock<TDependency> _dependencyMock;
    private readonly IDependencyBuilder<TSut> _mockDependencyBuilder;
    private readonly IArrangement _arrangement;

    public MockAsyncResultDependencyBuilder(
        Expression<Func<TDependency, Task<TResult>>> expression,
        IMock<TDependency> dependencyMock,
        IDependencyBuilder<TSut> mockDependencyBuilder,
        IArrangement arrangement
        )
    {
        _expression = expression;
        _dependencyMock = dependencyMock;
        _mockDependencyBuilder = mockDependencyBuilder;
        _arrangement = arrangement;
    }
    
    public IDependencyBuilder<TSut> AndReturns(
        TResult result
        )
    {
        _dependencyMock.MoqMock.Setup(_expression).ReturnsAsync(result);

        return _mockDependencyBuilder;
    }

    public IDependencyBuilder<TSut> AndReturns(
        Func<IReadArrangement, TResult> resultFunc
        )
    {
        var expectedResult = resultFunc.Invoke(_arrangement);
    
        _dependencyMock.MoqMock.Setup(_expression).ReturnsAsync(expectedResult);
    
        return _mockDependencyBuilder;
    }
}