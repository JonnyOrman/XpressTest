namespace XpressTest;

public class ResultPropertyAsserter<TResult, TProperty> : IResultPropertyAsserter<TResult, TProperty>
{
    private readonly IResultPropertyValueAsserter<TResult, TProperty> _resultPropertyValueAsserter;

    private readonly IResultPropertyNullAsserter<TResult> _resultPropertyNullAsserter;

    public ResultPropertyAsserter(
        IResultPropertyValueAsserter<TResult, TProperty> resultPropertyValueAsserter,
        IResultPropertyNullAsserter<TResult> resultPropertyNullAsserter
        )
    {
        _resultPropertyValueAsserter = resultPropertyValueAsserter;
        _resultPropertyNullAsserter = resultPropertyNullAsserter;
    }

    public IResultPropertyTargeter<TResult> ShouldBe(TProperty expectedValue)
    {
        return _resultPropertyValueAsserter.Assert(expectedValue);
    }

    public IResultPropertyTargeter<TResult> ShouldBeNull()
    {
        return _resultPropertyNullAsserter.Assert();
    }
}
