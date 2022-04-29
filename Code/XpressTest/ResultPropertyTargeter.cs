namespace XpressTest;

public class ResultPropertyTargeter<TSut, TResult> : IResultPropertyTargeter<TSut, TResult>
{
    private readonly TResult _result;
    private readonly ISutArrangement<TSut> _arrangement;

    public ResultPropertyTargeter(
        TResult result,
        ISutArrangement<TSut> arrangement)
    {
        _result = result;
        _arrangement = arrangement;
    }

    public IResultPropertyAsserter<TSut, TResult, TProperty> ThenTheResult<TProperty>(
        Func<TResult, TProperty> targetFunc
        )
    {
        var resultPropertyValueComparer = new ResultPropertyValueComparer<TResult, TProperty>(
            _result,
            targetFunc
            );

        var resultPropertyValueAsserter = new ResultPropertyValueAsserter<TSut, TResult, TProperty>(
            resultPropertyValueComparer,
            this
        );

        var resultPropertyNullComparer = new ResultPropertyNullComparer<TResult, TProperty>(
            _result,
            targetFunc
            );

        var resultPropertyNullAsserter = new ResultPropertyNullAsserter<TSut, TResult>(
            resultPropertyNullComparer,
            this
            );

        return new ResultPropertyAsserter<TSut, TResult, TProperty>(
            resultPropertyValueAsserter,
            resultPropertyNullAsserter,
            _arrangement
            );
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<ISutArrangement<TSut>, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);

        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBeA<TExpectedType>()
    {
        _result.ThenTheResultShouldBeA<TExpectedType>();
    }
}
