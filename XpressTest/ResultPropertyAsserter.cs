namespace XpressTest;

public class ResultPropertyAsserter<TSut, TResult, TProperty>
    :
        IResultPropertyAsserter<TSut, TResult, TProperty>
{
    private readonly IResultPropertyValueAsserter<TSut, TResult, TProperty> _resultPropertyValueAsserter;
    private readonly IResultPropertyNullAsserter<TSut, TResult> _resultPropertyNullAsserter;
    private readonly ISutArrangement<TSut> _arrangement;

    public ResultPropertyAsserter(
        IResultPropertyValueAsserter<TSut, TResult, TProperty> resultPropertyValueAsserter,
        IResultPropertyNullAsserter<TSut, TResult> resultPropertyNullAsserter,
        ISutArrangement<TSut> arrangement
        )
    {
        _resultPropertyValueAsserter = resultPropertyValueAsserter;
        _resultPropertyNullAsserter = resultPropertyNullAsserter;
        _arrangement = arrangement;
    }

    public IResultPropertyTargeter<TSut, TResult> ShouldBe(
        TProperty expectedValue
        )
    {
        return _resultPropertyValueAsserter.Assert(expectedValue);
    }

    public IResultPropertyTargeter<TSut, TResult> ShouldBe(
        Func<IReadArrangement, TProperty> expectedValueFunc
        )
    {
        var expectedValue = expectedValueFunc.Invoke(_arrangement);
        
        return _resultPropertyValueAsserter.Assert(expectedValue);
    }

    public IResultPropertyTargeter<TSut, TResult> ShouldBeNull()
    {
        return _resultPropertyNullAsserter.Assert();
    }
}
