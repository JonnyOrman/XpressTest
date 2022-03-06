using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockVoidCallCountVerifier<TMock> : IMockCallCountVerifier
    where TMock : class
{
    private readonly Mock<TMock> _mock;
    private readonly Expression<System.Action<TMock>> _expression;

    public MockVoidCallCountVerifier(
        Mock<TMock> mock,
        Expression<System.Action<TMock>> expression
        )
    {
        _mock = mock;
        _expression = expression;
    }

    public void Verify(int expectedNumberOfCalls)
    {
        _mock.Verify(_expression, Times.Exactly(expectedNumberOfCalls));
    }
}