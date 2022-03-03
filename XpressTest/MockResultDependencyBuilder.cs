using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockResultDependencyBuilder<TSut, TDependency, TResult> : IMockResultDependencyBuilder<TSut, TDependency, TResult>
    where TDependency : class
{
    private readonly Expression<Func<TDependency, TResult>> _func;
    private readonly Mock<TDependency> _dependencyMock;
    private readonly IMockDependencyBuilder<TSut, TDependency> _mockDependencyBuilder;
    private readonly IArrangement _arrangement;
    
    public MockResultDependencyBuilder(
        Expression<Func<TDependency, TResult>> func,
        Mock<TDependency> dependencyMock,
        IMockDependencyBuilder<TSut, TDependency> mockDependencyBuilder,
        IArrangement arrangement
        )
    {
        _func = func;
        _dependencyMock = dependencyMock;
        _mockDependencyBuilder = mockDependencyBuilder;
        _arrangement = arrangement;
    }
    
    public IMockDependencyBuilder<TSut, TDependency> AndReturns(TResult result)
    {
        _dependencyMock.Setup(_func).Returns(result);

        return _mockDependencyBuilder;
    }

    public IMockDependencyBuilder<TSut, TDependency> AndReturns(Func<IArrangement, TResult> resultFunc)
    {
        var expectedResult = resultFunc.Invoke(_arrangement);

        _dependencyMock.Setup(_func).Returns(expectedResult);

        return _mockDependencyBuilder;
    }

    public IMockDependencyBuilder<TSut, TDependency> AndReturns<TReturn>()
        where TReturn : class, TResult
    {
        var result = _arrangement.GetMockObject<TReturn>();
        
        _dependencyMock.Setup(_func).Returns(result);

        return _mockDependencyBuilder;
    }
}
