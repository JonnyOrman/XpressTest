using System.Linq.Expressions;

namespace XpressTest;

public class MockCallCountVerifierCreator<TMock> : IMockCallCountVerifierCreator<TMock>
    where TMock : class
{
    private readonly IMock<TMock> _mock;

    public MockCallCountVerifierCreator(
        IMock<TMock> mock
        )
    {
        _mock = mock;
    }
    
    public IMockCallCountVerifier Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return new MockResultCallCountVerifier<TMock, TMockResult>(
            _mock,
            expression
            );
    }

    public IMockCallCountVerifier Create(
        Expression<Action<TMock>> expression
        )
    {
        return new MockVoidCallCountVerifier<TMock>(
            _mock,
            expression
        );
    }
}