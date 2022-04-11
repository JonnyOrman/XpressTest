using System.Linq.Expressions;

namespace XpressTest;

public class AsyncResultMockVerifier<TSut, TSutResult, TMock>
    :
        IAsyncResultMockVerifier<TSut, TSutResult, TMock>
{
    private readonly IMockCounterVerifierCreator<TMock, IAsyncResultAsserter<TSut, TSutResult>> _mockCounterVerifierCreator;
    private readonly IAsyncResultAsserter<TSut, TSutResult> _asserter;

    public AsyncResultMockVerifier(
        IMockCounterVerifierCreator<TMock, IAsyncResultAsserter<TSut, TSutResult>> mockCounterVerifierCreator,
        IAsyncResultAsserter<TSut, TSutResult> asserter
        )
    {
        _mockCounterVerifierCreator = mockCounterVerifierCreator;
        _asserter = asserter;
    }
    
    public IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
        );
    }

    public IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
        );
    }

    public IMockCounterVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }
}