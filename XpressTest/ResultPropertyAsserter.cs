namespace XpressTest;

public class ResultPropertyAsserter<TResult, TProperty> : IResultPropertyAsserter<TResult, TProperty>
{
    private readonly IResultPropertyValueAsserter<TResult, TProperty> _resultPropertyValueAsserter;
    private readonly IResultPropertyNullAsserter<TResult> _resultPropertyNullAsserter;
    private readonly IArrangement _arrangement;

    public ResultPropertyAsserter(
        IResultPropertyValueAsserter<TResult, TProperty> resultPropertyValueAsserter,
        IResultPropertyNullAsserter<TResult> resultPropertyNullAsserter,
        IArrangement arrangement
        )
    {
        _resultPropertyValueAsserter = resultPropertyValueAsserter;
        _resultPropertyNullAsserter = resultPropertyNullAsserter;
        _arrangement = arrangement;
    }

    public IResultPropertyTargeter<TResult> ShouldBe(TProperty expectedValue)
    {
        return _resultPropertyValueAsserter.Assert(expectedValue);
    }

    public IResultPropertyTargeter<TResult> ShouldBe(Func<IArrangement, TProperty> expectedValueFunc)
    {
        var expectedValue = expectedValueFunc.Invoke(_arrangement);
        
        return _resultPropertyValueAsserter.Assert(expectedValue);
    }

    public IResultPropertyTargeter<TResult> ShouldBeNull()
    {
        return _resultPropertyNullAsserter.Assert();
    }
}
