using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementResultMockCountVerifierCreator<TMock, TAsserter>
    :
        IArrangementResultMockCountVerifierCreator<TMock, TAsserter>
    where TMock : class
{
    private readonly IArrangementResultMockCallVerifierCreator<TMock, TAsserter> _arrangementResultMockCallVerifierCreator;

    public ArrangementResultMockCountVerifierCreator(
        IArrangementResultMockCallVerifierCreator<TMock, TAsserter> arrangementResultMockCallVerifierCreator
        )
    {
        _arrangementResultMockCallVerifierCreator = arrangementResultMockCallVerifierCreator;
    }
    
    public IMockCountVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
        )
    {
        var mockCallVerifier = _arrangementResultMockCallVerifierCreator.Create(
            func,
            asserter
        );
        
        return new MockCountVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}