using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementResultMockCounterVerifierCreator<TMock, TAsserter>
    :
        IArrangementResultMockCounterVerifierCreator<TMock, TAsserter>
    where TMock : class
{
    private readonly IArrangementResultMockCallVerifierCreator<TMock, TAsserter> _arrangementResultMockCallVerifierCreator;

    public ArrangementResultMockCounterVerifierCreator(
        IArrangementResultMockCallVerifierCreator<TMock, TAsserter> arrangementResultMockCallVerifierCreator
        )
    {
        _arrangementResultMockCallVerifierCreator = arrangementResultMockCallVerifierCreator;
    }
    
    public IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
        )
    {
        var mockCallVerifier = _arrangementResultMockCallVerifierCreator.Create(
            func,
            asserter
        );
        
        return new MockCounterVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}