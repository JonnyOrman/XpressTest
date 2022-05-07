using System.Linq.Expressions;
using XpressTest.Narration;

namespace XpressTest;

public class MockResultBuilder<TMock, TResult, TBuilder>
:
    IMockResultBuilder<TResult, TBuilder>
    where TMock : class
{
    private readonly Expression<Func<TMock, TResult>> _expression;
    private readonly IMock<TMock> _objectMock;
    private readonly TBuilder _mockObjectBuilder;
    private readonly IArrangement _arrangement;
    private readonly IValueNarrator<TResult> _resultNarrator;

    public MockResultBuilder(
        Expression<Func<TMock, TResult>> expression,
        IMock<TMock> objectMock,
        TBuilder mockObjectBuilder,
        IArrangement arrangement,
        IValueNarrator<TResult> resultNarrator 
    )
    {
        _expression = expression;
        _objectMock = objectMock;
        _mockObjectBuilder = mockObjectBuilder;
        _arrangement = arrangement;
        _resultNarrator = resultNarrator;
    }

    public TBuilder AndReturns(
        TResult expectedResult
    )
    {
        _resultNarrator.Narrate(expectedResult);
        
        _objectMock.MoqMock.Setup(_expression).Returns(expectedResult);

        return _mockObjectBuilder;
    }

    public TBuilder AndReturns(
        Func<IReadArrangement, TResult> func
    )
    {
        var expectedResult = func.Invoke(_arrangement);

        return AndReturns(expectedResult);
    }

    public TBuilder AndReturnsTheMock<TReturn>()
        where TReturn : class, TResult
    {
        var expectedResult = _arrangement.GetTheMockObject<TReturn>();

        return AndReturns(expectedResult);
    }
}