using System.Linq.Expressions;

namespace XpressTest;

public class MockCounterVerifierCreator<TMock, TAsserter>
    :
        IMockCounterVerifierCreator<TMock, TAsserter>
where TMock : class
{
    private readonly IResultMockCounterVerifierCreator<TMock, TAsserter> _resultMockCounterVerifierCreator;
    private readonly IArrangementResultMockCounterVerifierCreator<TMock, TAsserter> _arrangementResultMockCounterVerifierCreator;
    private readonly IVoidMockCounterVerifierCreator<TMock, TAsserter> _voidMockCounterVerifierCreator;
    private readonly IArrangementVoidMockCounterVerifierCreator<TMock, TAsserter> _arrangementVoidMockCounterVerifierCreator;

    public MockCounterVerifierCreator(
        IResultMockCounterVerifierCreator<TMock, TAsserter> resultMockCounterVerifierCreator,
        IArrangementResultMockCounterVerifierCreator<TMock, TAsserter> arrangementResultMockCounterVerifierCreator,
        IVoidMockCounterVerifierCreator<TMock, TAsserter> voidMockCounterVerifierCreator,
        IArrangementVoidMockCounterVerifierCreator<TMock, TAsserter> arrangementVoidMockCounterVerifierCreator
        )
    {
        _resultMockCounterVerifierCreator = resultMockCounterVerifierCreator;
        _arrangementResultMockCounterVerifierCreator = arrangementResultMockCounterVerifierCreator;
        _voidMockCounterVerifierCreator = voidMockCounterVerifierCreator;
        _arrangementVoidMockCounterVerifierCreator = arrangementVoidMockCounterVerifierCreator;
    }
    
    public IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _resultMockCounterVerifierCreator.Create(
            expression
        );
    }

    public IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
        )
    {
        return _arrangementResultMockCounterVerifierCreator.Create(
            func,
            asserter
            );
    }

    public IMockCounterVerifier<TAsserter> Create(
        Func<IArrangement, Expression<System.Action<TMock>>> func,
        TAsserter asserter
        )
    {
        return _arrangementVoidMockCounterVerifierCreator.Create(
            func,
            asserter
            );
    }

    public IMockCounterVerifier<TAsserter> Create(
        Expression<System.Action<TMock>> expression
        )
    {
        return _voidMockCounterVerifierCreator.Create(
            expression
        );
    }
}