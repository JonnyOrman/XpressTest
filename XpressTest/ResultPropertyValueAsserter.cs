namespace XpressTest;

public class ResultPropertyValueAsserter<TResult, TProperty>
:
    IResultPropertyValueAsserter<TResult, TProperty>
{
    private readonly IResultPropertyValueComparer<TProperty> _resultPropertyValueComparer;

    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;
    
    public ResultPropertyValueAsserter(
        IResultPropertyValueComparer<TProperty> resultPropertyValueComparer,
        IResultPropertyTargeter<TResult>  resultPropertyTargeter
        )
    {
        _resultPropertyValueComparer = resultPropertyValueComparer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public IResultPropertyTargeter<TResult> Assert(TProperty expectedValue)
    {
        _resultPropertyValueComparer.Compare(expectedValue);

        return _resultPropertyTargeter;
    }
}