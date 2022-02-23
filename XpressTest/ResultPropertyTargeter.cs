namespace XpressTest;

public class ResultPropertyTargeter<TResult> : IResultPropertyTargeter<TResult>
{
    private readonly TResult _result;

    public ResultPropertyTargeter(TResult result)
    {
        _result = result;
    }

    public IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(
        Func<TResult, TProperty> targetFunc
        )
    {
        return new ResultPropertyAsserter<TResult, TProperty>(
            _result,
            targetFunc
            );
    }
    
    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _result.ThenTheResultShouldBe(expectedResult);
    }
}
