using Xunit;

namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IResultAsserter<TSut, TResult>
    where TSut : class
{
    private readonly TResult _result;
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;

    public ResultAsserter(
        TResult result,
        ISutComposer<TSut> sutComposer,
        IResultPropertyTargeter<TResult> resultPropertyTargeter
        )
    {
        _result = result;
        _sutComposer = sutComposer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public void Then(System.Action<IAssertion<TSut, TResult>> action)
    {
        var sutComposer = new SutComposer<TSut>(
            _sutComposer.Arrangement
        );
        
        var sut = sutComposer.Compose();

        var sutAction = new Action<TSut>(sut, _sutComposer.Arrangement);
        
        var assertion = new Assertion<TSut, TResult>(
            _result,
            sutAction);

        action.Invoke(assertion);
    }

    public IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class
    {
        var mock = _sutComposer.Arrangement.GetMock<TMock>();
        
        return new ResultMockVerifier<TSut, TResult, TMock>(
            _result,
            mock,
            _sutComposer,
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
}