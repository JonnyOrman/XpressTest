namespace XpressTest;

public class ResultPropertyValueAsserter<TSut, TResult, TProperty>
:
    IResultPropertyValueAsserter<TSut, TResult, TProperty>
{
    private readonly IResultPropertyValueComparer<TProperty> _resultPropertyValueComparer;

    private readonly IResultPropertyTargeter<TSut, TResult> _resultPropertyTargeter;

    public ResultPropertyValueAsserter(
        IResultPropertyValueComparer<TProperty> resultPropertyValueComparer,
        IResultPropertyTargeter<TSut, TResult> resultPropertyTargeter
        )
    {
        _resultPropertyValueComparer = resultPropertyValueComparer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }

    public IResultPropertyTargeter<TSut, TResult> Assert(TProperty expectedValue)
    {
        _resultPropertyValueComparer.Compare(expectedValue);

        return _resultPropertyTargeter;
    }
}