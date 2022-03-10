using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockCounterVerifierCreator<TMock, TAsserter>
    :
        IVoidMockCounterVerifierCreator<TMock, TAsserter>
{
    private readonly IVoidMockCallVerifierCreator<TMock, TAsserter> _voidMockCallVerifierCreator;

    public VoidMockCounterVerifierCreator(
        IVoidMockCallVerifierCreator<TMock, TAsserter> voidMockCallVerifierCreator
        )
    {
        _voidMockCallVerifierCreator = voidMockCallVerifierCreator;
    }
    
    public IMockCounterVerifier<TAsserter> Create(
        Expression<System.Action<TMock>> expression
        )
    {
        var mockCallVerifier = _voidMockCallVerifierCreator.Create(
            expression
        );
        
        return new MockCounterVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}