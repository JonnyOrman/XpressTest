using System.Linq.Expressions;

namespace XpressTest;

public class VoidMockCountVerifierCreator<TMock, TAsserter>
    :
        IVoidMockCountVerifierCreator<TMock, TAsserter>
{
    private readonly IVoidMockCallVerifierCreator<TMock, TAsserter> _voidMockCallVerifierCreator;

    public VoidMockCountVerifierCreator(
        IVoidMockCallVerifierCreator<TMock, TAsserter> voidMockCallVerifierCreator
        )
    {
        _voidMockCallVerifierCreator = voidMockCallVerifierCreator;
    }
    
    public IMockCountVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
        )
    {
        var mockCallVerifier = _voidMockCallVerifierCreator.Create(
            expression
        );
        
        return new MockCountVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}