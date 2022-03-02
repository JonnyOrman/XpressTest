using System.Linq.Expressions;
using Moq;

namespace XpressTest;

public class ResultMockCounterVerifier<TSut, TResult, TMock, TMockResult> : IResultMockCounterVerifier<TSut, TResult>
    where TSut : class
    where TMock : class
{
    private readonly TResult _result;
    private readonly Mock<TMock> _mock;
    private readonly Expression<Func<TMock, TMockResult>> _func;
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> _sutTesterComposer;
    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;
    
    public ResultMockCounterVerifier(
        TResult result,
        Mock<TMock> mock,
        Expression<Func<TMock, TMockResult>> func,
        ISutComposer<TSut> sutComposer,
        ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> sutTesterComposer,
        IResultPropertyTargeter<TResult> resultPropertyTargeter
        )
    {
        _result = result;
        _mock = mock;
        _func = func;
        _sutComposer = sutComposer;
        _sutTesterComposer = sutTesterComposer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public IResultAsserter<TSut, TResult> Once()
    {
        _mock.Verify(_func, Times.Once);

        return new ResultAsserter<TSut, TResult>(
            _result,
            _sutComposer,
            _sutTesterComposer,
            _resultPropertyTargeter
        );
    }

    public IResultAsserter<TSut, TResult> Never()
    {
        _mock.Verify(_func, Times.Never);

        return new ResultAsserter<TSut, TResult>(
            _result,
            _sutComposer,
            _sutTesterComposer,
            _resultPropertyTargeter
        );
    }
}