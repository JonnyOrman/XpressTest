using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementVoidMockCounterVerifierCreator<TMock, TAsserter>
    :
        IArrangementVoidMockCounterVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IArrangementVoidMockCallVerifierCreator<TMock, TAsserter> _arrangementVoidMockCallVerifierCreator;

    public ArrangementVoidMockCounterVerifierCreator(
        IArrangementVoidMockCallVerifierCreator<TMock, TAsserter> arrangementVoidMockCallVerifierCreator
        )
    {
        _arrangementVoidMockCallVerifierCreator = arrangementVoidMockCallVerifierCreator;
    }
    
    public IMockCounterVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
        )
    {
        var mockCallVerifier = _arrangementVoidMockCallVerifierCreator.Create(
            func,
            asserter
            );
        
        return new MockCounterVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}