using System.Linq.Expressions;

namespace XpressTest;

public class MockResultDependencyBuilder<TSut, TDependency, TResult>
    :
        IMockResultDependencyBuilder<TSut, TResult>
    where TDependency : class
{
    private readonly Expression<Func<TDependency, TResult>> _func;
    private readonly IMock<TDependency> _dependencyMock;
    private readonly IDependencyBuilder<TSut> _mockDependencyBuilder;
    private readonly IArrangement _arrangement;
    
    public MockResultDependencyBuilder(
        Expression<Func<TDependency, TResult>> func,
        IMock<TDependency> dependencyMock,
        IDependencyBuilder<TSut> mockDependencyBuilder,
        IArrangement arrangement
        )
    {
        _func = func;
        _dependencyMock = dependencyMock;
        _mockDependencyBuilder = mockDependencyBuilder;
        _arrangement = arrangement;
    }
    
    public IDependencyBuilder<TSut> AndReturns(
        TResult result
        )
    {
        _dependencyMock.MoqMock.Setup(_func).Returns(result);

        return _mockDependencyBuilder;
    }

    public IDependencyBuilder<TSut> AndReturns(
        Func<IReadArrangement, TResult> resultFunc
        )
    {
        var expectedResult = resultFunc.Invoke(_arrangement);

        _dependencyMock.MoqMock.Setup(_func).Returns(expectedResult);

        return _mockDependencyBuilder;
    }

    public IDependencyBuilder<TSut> AndReturnsTheMock<TReturn>()
        where TReturn : class, TResult
    {
        var result = _arrangement.GetTheMockObject<TReturn>();
        
        _dependencyMock.MoqMock.Setup(_func).Returns(result);

        return _mockDependencyBuilder;
    }
}
