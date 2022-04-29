using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementVoidMockCountVerifierCreator<TMock, TAsserter>
    :
        IArrangementVoidMockCountVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IArrangementVoidMockCallVerifierCreator<TMock, TAsserter> _arrangementVoidMockCallVerifierCreator;

    public ArrangementVoidMockCountVerifierCreator(
        IArrangementVoidMockCallVerifierCreator<TMock, TAsserter> arrangementVoidMockCallVerifierCreator
        )
    {
        _arrangementVoidMockCallVerifierCreator = arrangementVoidMockCallVerifierCreator;
    }

    public IMockCountVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
        )
    {
        var mockCallVerifier = _arrangementVoidMockCallVerifierCreator.Create(
            func,
            asserter
            );

        return new MockCountVerifier<TAsserter>(
            mockCallVerifier
        );
    }
}