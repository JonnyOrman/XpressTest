using System.Linq.Expressions;

namespace XpressTest;

public class ResultMockVerifier<TSut, TSutResult, TMock>
    :
        IResultMockVerifier<TSut, TSutResult, TMock>
    where TSut : class
    where TMock : class
{
    private readonly IMockCounterVerifierCreator<TMock, IResultAsserter<TSut, TSutResult>> _mockCounterVerifierCreator;
    private readonly IResultAsserter<TSut, TSutResult> _asserter;

    public ResultMockVerifier(
        IMockCounterVerifierCreator<TMock, IResultAsserter<TSut, TSutResult>> mockCounterVerifierCreator,
        IResultAsserter<TSut, TSutResult> asserter
        )
    {
        _mockCounterVerifierCreator = mockCounterVerifierCreator;
        _asserter = asserter;
    }
    
    public IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
            );
    }

    public IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }

    public IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Func<IArrangement, Expression<System.Action<TMock>>> func
        )
    {
        return _mockCounterVerifierCreator.Create(
            func,
            _asserter
        );
    }

    public IMockCounterVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Expression<System.Action<TMock>> expression
        )
    {
        return _mockCounterVerifierCreator.Create(
            expression
        );
    }
}