using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockResultCallCountVerifier<TMock, TMockResult> : IMockCallCountVerifier
    where TMock : class
{
    private readonly IMock<TMock> _mock;
    private readonly Expression<Func<TMock, TMockResult>> _expression;

    public MockResultCallCountVerifier(
        IMock<TMock> mock,
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        _mock = mock;
        _expression = expression;
    }
    
    public void Verify(int numberOfCalls)
    {
        _mock.MoqMock.Verify(_expression, Times.Exactly(numberOfCalls));
    }
}