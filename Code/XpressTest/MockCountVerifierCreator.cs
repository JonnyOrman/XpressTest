using System.Linq.Expressions;

namespace XpressTest;

public class MockCountVerifierCreator<TMock, TAsserter>
    :
        IMockCountVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IResultMockCountVerifierCreator<TMock, TAsserter> _resultMockCountVerifierCreator;
    private readonly IArrangementResultMockCountVerifierCreator<TMock, TAsserter> _arrangementResultMockCountVerifierCreator;
    private readonly IVoidMockCountVerifierCreator<TMock, TAsserter> _voidMockCountVerifierCreator;
    private readonly IArrangementVoidMockCountVerifierCreator<TMock, TAsserter> _arrangementVoidMockCountVerifierCreator;

    public MockCountVerifierCreator(
        IResultMockCountVerifierCreator<TMock, TAsserter> resultMockCountVerifierCreator,
        IArrangementResultMockCountVerifierCreator<TMock, TAsserter> arrangementResultMockCountVerifierCreator,
        IVoidMockCountVerifierCreator<TMock, TAsserter> voidMockCounterVerifierCreator,
        IArrangementVoidMockCountVerifierCreator<TMock, TAsserter> arrangementVoidMockCountVerifierCreator
        )
    {
        _resultMockCountVerifierCreator = resultMockCountVerifierCreator;
        _arrangementResultMockCountVerifierCreator = arrangementResultMockCountVerifierCreator;
        _voidMockCountVerifierCreator = voidMockCounterVerifierCreator;
        _arrangementVoidMockCountVerifierCreator = arrangementVoidMockCountVerifierCreator;
    }

    public IMockCountVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _resultMockCountVerifierCreator.Create(
            expression
        );
    }

    public IMockCountVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
        )
    {
        return _arrangementResultMockCountVerifierCreator.Create(
            func,
            asserter
            );
    }

    public IMockCountVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
    )
    {
        return _voidMockCountVerifierCreator.Create(
            expression
        );
    }

    public IMockCountVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
        )
    {
        return _arrangementVoidMockCountVerifierCreator.Create(
            func,
            asserter
            );
    }
}