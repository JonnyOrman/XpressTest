using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockCallVerifierCreator<TMock, TAsserter>
    :
        IVoidMockCallVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IMockCallCountVerifierCreator<TMock> _mockCallCountVerifierCreator;
    private readonly TAsserter _asserter;

    public VoidMockCallVerifierCreator(
        IMockCallCountVerifierCreator<TMock> mockCallCountVerifierCreator,
        TAsserter asserter
        )
    {
        _mockCallCountVerifierCreator = mockCallCountVerifierCreator;
        _asserter = asserter;
    }
    
    public IMockCallVerifier<TAsserter> Create(Expression<System.Action<TMock>> expression)
    {
        var mockCallCountVerifier = _mockCallCountVerifierCreator.Create(
            expression
        );
        
        return new MockCallVerifier<TAsserter>(
            mockCallCountVerifier,
            _asserter
        );
    }
}