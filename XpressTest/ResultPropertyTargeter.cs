namespace XpressTest;

public class ResultPropertyTargeter<TResult> : IResultPropertyTargeter<TResult>
{
    private readonly TResult _result;
    private readonly IArrangement _arrangement;

    public ResultPropertyTargeter(
        TResult result,
        IArrangement arrangement)
    {
        _result = result;
        _arrangement = arrangement;
    }

    public IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(
        Func<TResult, TProperty> targetFunc
        )
    {
        return new ResultPropertyAsserter<TResult, TProperty>(
            _result,
            targetFunc,
            _arrangement
            );
    }
    
    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<IArrangement, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);
        
        _result.ThenTheResultShouldBe(expectedResult);
    }
}
