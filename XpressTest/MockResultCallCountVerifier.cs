using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockResultCallCountVerifier<TMock, TMockResult> : IMockCallCountVerifier
    where TMock : class
{
    private readonly Mock<TMock> _mock;
    private readonly Expression<Func<TMock, TMockResult>> _expression;

    public MockResultCallCountVerifier(
        Mock<TMock> mock,
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        _mock = mock;
        _expression = expression;
    }
    
    public void Verify(int numberOfCalls)
    {
        _mock.Verify(_expression, Times.Exactly(numberOfCalls));
    }
}