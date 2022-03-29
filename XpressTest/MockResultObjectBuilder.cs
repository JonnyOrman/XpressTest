using System.Linq.Expressions;
using Moq;

namespace XpressTest;

public class MockResultObjectBuilder<TSut, TObject, TResult>
    :
        IMockResultObjectBuilder<TSut, TObject, TResult>
where TObject : class
{
    private readonly Expression<Func<TObject, TResult>> _expression;
    private readonly Mock<TObject> _objectMock;
    private readonly IMockObjectBuilder<TSut, TObject> _mockObjectBuilder;
    private readonly IArrangement _arrangement;

    public MockResultObjectBuilder(
        Expression<Func<TObject, TResult>> expression,
        Mock<TObject> objectMock,
        IMockObjectBuilder<TSut, TObject> mockObjectBuilder,
        IArrangement arrangement
        )
    {
        _expression = expression;
        _objectMock = objectMock;
        _mockObjectBuilder = mockObjectBuilder;
        _arrangement = arrangement;
    }
    
    public IMockObjectBuilder<TSut, TObject> AndReturns(Func<IArrangement, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);

        _objectMock.Setup(_expression).Returns(expectedResult);

        return _mockObjectBuilder;
    }

    public IMockObjectBuilder<TSut, TObject> AndReturns(TResult expectedResult)
    {
        _objectMock.Setup(_expression).Returns(expectedResult);

        return _mockObjectBuilder;
    }

    public IMockObjectBuilder<TSut, TObject> AndReturns<TMock>()
        where TMock : class, TResult
    {
        var mockObject = _arrangement.GetMockObject<TMock>();
        
        _objectMock.Setup(_expression).Returns(mockObject);

        return _mockObjectBuilder;
    }
}