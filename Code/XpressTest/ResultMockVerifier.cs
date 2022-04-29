using System.Linq.Expressions;

namespace XpressTest;

public class ResultMockVerifier<TSut, TSutResult, TMock>
    :
        IResultMockVerifier<TSut, TSutResult, TMock>
    where TSut : class
    where TMock : class
{
    private readonly IMockCountVerifierCreator<TMock, IResultAsserter<TSut, TSutResult>> _mockCounterVerifierCreator;
    private readonly IResultAsserter<TSut, TSutResult> _asserter;

    public ResultMockVerifier(
        IMockCountVerifierCreator<TMock, IResultAsserter<TSut, TSutResult>> mockCounterVerifierCreator,
        IResultAsserter<TSut, TSutResult> asserter
        )
    {
        _mockCounterVerifierCreator = mockCounterVerifierCreator;
        _asserter = asserter;
    }

    public IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
            );
    }

    public IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }

    public IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
        );
    }

    public IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Expression<Action<TMock>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }
}