using Xunit;

namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IResultAsserter<TSut, TResult>
    where TSut : class
{
    private readonly TResult _result;
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> _sutTesterComposer;
    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;

    public ResultAsserter(
        TResult result,
        ISutComposer<TSut> sutComposer,
        ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> sutTesterComposer,
        IResultPropertyTargeter<TResult> resultPropertyTargeter
        )
    {
        _result = result;
        _sutComposer = sutComposer;
        _sutTesterComposer = sutTesterComposer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public ITester Then(System.Action<IAssertion<TSut, TResult>> assertion)
    {
        var sutTester = _sutTesterComposer.Compose(assertion);

        return new Tester<TSut>(
            _sutComposer,
            sutTester
            );
    }

    public IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class
    {
        var mock = _sutComposer.Arrangement.GetMock<TMock>();
        
        return new ResultMockVerifier<TSut, TResult, TMock>(
            _result,
            mock,
            _sutComposer,
            _sutTesterComposer,
            _resultPropertyTargeter
            );
    }

    public void ThenTheResultShouldBeNull()
    {
        Assert.Null(_result);
    }

    public IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc)
    {
        return _resultPropertyTargeter.ThenTheResult(targetFunc);
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _resultPropertyTargeter.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<IArrangement, TResult> func)
    {
        var expectedResult = func.Invoke(_sutComposer.Arrangement);
        
        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBeB(Func<IArrangement, TResult> func)
    {
        throw new NotImplementedException();
    }
}