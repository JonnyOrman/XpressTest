using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockResultDependencyBuilder<TSut, TDependency, TResult>
    :
        IMockResultDependencyBuilder<TSut, TDependency, TResult>
where TDependency : class
{
    private readonly Expression<Func<TDependency, TResult>> _expression;
    private readonly INamedMock<TDependency> _namedMock;
    private readonly IMockDependencyBuilder<TSut, TDependency> _mockDependencyBuilder;
    private readonly IArrangement _arrangement;

    public NamedMockResultDependencyBuilder(
        Expression<Func<TDependency, TResult>> expression,
        INamedMock<TDependency> namedMock,
        IMockDependencyBuilder<TSut, TDependency> mockDependencyBuilder,
        IArrangement arrangement
        )
    {
        _expression = expression;
        _namedMock = namedMock;
        _mockDependencyBuilder = mockDependencyBuilder;
        _arrangement = arrangement;
    }
    
    public IMockDependencyBuilder<TSut, TDependency> AndReturns(TResult expectedResult)
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TDependency> AndReturns(Func<IArrangement, TResult> expectedResultFunc)
    {
        var expectedResult = expectedResultFunc.Invoke(_arrangement);

        _namedMock.Mock.Setup(_expression).Returns(expectedResult);

        return _mockDependencyBuilder;
    }

    public IMockDependencyBuilder<TSut, TDependency> AndReturns<TReturn>() where TReturn : class, TResult
    {
        throw new NotImplementedException();
    }
}