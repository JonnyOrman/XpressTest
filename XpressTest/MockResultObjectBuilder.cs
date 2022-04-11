using System.Linq.Expressions;

namespace XpressTest;

public class MockResultObjectBuilder<TSut, TObject, TResult>
    :
        IMockSetupResultBuilder<TSut, TObject, TResult>
where TObject : class
{
    private readonly Expression<Func<TObject, TResult>> _expression;
    private readonly IMock<TObject> _objectMock;
    private readonly IMockSetupBuilder<TSut, TObject> _mockObjectBuilder;
    private readonly IArrangement _arrangement;

    public MockResultObjectBuilder(
        Expression<Func<TObject, TResult>> expression,
        IMock<TObject> objectMock,
        IMockSetupBuilder<TSut, TObject> mockObjectBuilder,
        IArrangement arrangement
        )
    {
        _expression = expression;
        _objectMock = objectMock;
        _mockObjectBuilder = mockObjectBuilder;
        _arrangement = arrangement;
    }
    
    public IMockSetupBuilder<TSut, TObject> AndReturns(Func<IReadArrangement, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);

        _objectMock.MoqMock.Setup(_expression).Returns(expectedResult);

        return _mockObjectBuilder;
    }

    public IMockSetupBuilder<TSut, TObject> AndReturns(TResult expectedResult)
    {
        _objectMock.MoqMock.Setup(_expression).Returns(expectedResult);

        return _mockObjectBuilder;
    }

    public IMockSetupBuilder<TSut, TObject> AndReturnsTheMock<TMock>()
        where TMock : class, TResult
    {
        var mockObject = _arrangement.GetTheMockObject<TMock>();
        
        _objectMock.MoqMock.Setup(_expression).Returns(mockObject);

        return _mockObjectBuilder;
    }
}