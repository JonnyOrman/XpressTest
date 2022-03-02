using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class ResultMockVerifier<TSut, TSutResult, TMock> : IResultMockVerifier<TSut, TSutResult, TMock>
    where TSut : class
    where TMock : class
{
    private readonly TSutResult _result;
    private readonly Mock<TMock> _mock;
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TSutResult>>> _sutTesterComposer;
    private readonly IResultPropertyTargeter<TSutResult> _resultPropertyTargeter;

    public ResultMockVerifier(
        TSutResult result,
        Mock<TMock> mock,
        ISutComposer<TSut> sutComposer,
        ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TSutResult>>> sutTesterComposer,
        IResultPropertyTargeter<TSutResult> resultPropertyTargeter
        )
    {
        _result = result;
        _mock = mock;
        _sutComposer = sutComposer;
        _sutTesterComposer = sutTesterComposer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public IResultMockCounterVerifier<TSut, TSutResult> Should<TResult>(Func<IArrangement, Expression<Func<TMock, TResult>>> func)
    {
        return new ArrangementResultMockCounterVerifier<TSut, TSutResult, TMock, TResult>(
            _result,
            _mock,
            func,
            _sutComposer,
            _sutTesterComposer,
            _resultPropertyTargeter
            );
    }

    public IResultMockCounterVerifier<TSut, TSutResult> Should<TResult>(Expression<Func<TMock, TResult>> func)
    {
        return new ResultMockCounterVerifier<TSut, TSutResult, TMock, TResult>(
            _result,
            _mock,
            func,
            _sutComposer,
            _sutTesterComposer,
            _resultPropertyTargeter
        );
    }
}