using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class ArrangementResultMockCounterVerifier<TSut, TResult, TMock, TMockResult> : IResultMockCounterVerifier<TSut, TResult>
    where TSut : class
    where TMock : class
{
    private readonly TResult _result;
    private readonly Mock<TMock> _mock;
    private readonly Func<IArrangement, Expression<Func<TMock, TMockResult>>> _func;
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> _sutTesterComposer;
    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;

    public ArrangementResultMockCounterVerifier(
        TResult result,
        Mock<TMock> mock,
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func,
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
        _mock.Verify(_func.Invoke(_sutComposer.Arrangement), Times.Once);

        return new ResultAsserter<TSut, TResult>(
            _result,
            _sutComposer,
            _sutTesterComposer,
            _resultPropertyTargeter
            );
    }

    public IResultAsserter<TSut, TResult> Never()
    {
        throw new NotImplementedException();
    }
}