using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockResultObjectBuilder<TSut, TObject, TResult>
    :
        INamedMockResultObjectBuilder<TSut, TObject, TResult>
where TObject : class
{
    private readonly Expression<Func<TObject, TResult>> _expression;
    private readonly INamedMock<TObject> _namedMock;
    private readonly INamedMockObjectBuilder<TSut, TObject> _mockObjectBuilder;

    public NamedMockResultObjectBuilder(
        Expression<Func<TObject, TResult>> expression,
        INamedMock<TObject> namedMock,
        INamedMockObjectBuilder<TSut, TObject> mockObjectBuilder
        )
    {
        _expression = expression;
        _namedMock = namedMock;
        _mockObjectBuilder = mockObjectBuilder;
    }
    
    public INamedMockObjectBuilder<TSut, TObject> AndReturns(TResult expectedResult)
    {
        _namedMock.Mock.Setup(_expression).Returns(expectedResult);

        return _mockObjectBuilder;
    }
}