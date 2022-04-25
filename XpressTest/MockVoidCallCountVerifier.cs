using System.Linq.Expressions;
using Moq;

namespace XpressTest;

public class MockVoidCallCountVerifier<TMock>
    :
        IMockCallCountVerifier
    where TMock : class
{
    private readonly IMock<TMock> _mock;
    private readonly Expression<Action<TMock>> _expression;

    public MockVoidCallCountVerifier(
        IMock<TMock> mock,
        Expression<Action<TMock>> expression
        )
    {
        _mock = mock;
        _expression = expression;
    }

    public void Verify(int expectedNumberOfCalls)
    {
        _mock.MoqMock.Verify(_expression, Times.Exactly(expectedNumberOfCalls));
    }
}