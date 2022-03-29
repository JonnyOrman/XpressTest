using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockResultDependencyBuilder<TSut, TDependency, TResult>
    :
        INamedMockResultDependencyBuilder<TSut, TDependency, TResult>
where TDependency : class
{
    private readonly Expression<Func<TDependency, TResult>> _expression;
    private readonly INamedMock<TDependency> _namedMock;
    private readonly INamedMockDependencyBuilder<TSut, TDependency> _namedMockDependencyBuilder;
    private readonly IArrangement _arrangement;

    public NamedMockResultDependencyBuilder(
        Expression<Func<TDependency, TResult>> expression,
        INamedMock<TDependency> namedMock,
        INamedMockDependencyBuilder<TSut, TDependency> namedMockDependencyBuilder,
        IArrangement arrangement
        )
    {
        _expression = expression;
        _namedMock = namedMock;
        _namedMockDependencyBuilder = namedMockDependencyBuilder;
        _arrangement = arrangement;
    }
    
    public INamedMockDependencyBuilder<TSut, TDependency> AndReturns(Func<IArrangement, TResult> expectedResultFunc)
    {
        var expectedResult = expectedResultFunc.Invoke(_arrangement);

        _namedMock.Mock.Setup(_expression).Returns(expectedResult);

        return _namedMockDependencyBuilder;
    }
}