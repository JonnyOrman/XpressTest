namespace XpressTest;

public class ResultPropertyValueComparer<TResult, TProperty>
    :
        IResultPropertyValueComparer<TProperty>
{
    private readonly TResult _result;
    private readonly Func<TResult, TProperty> _targetFunc;

    public ResultPropertyValueComparer(
        TResult result,
        Func<TResult, TProperty> targetFunc
        )
    {
        _result = result;
        _targetFunc = targetFunc;
    }
    
    public void Compare(TProperty expectedValue)
    {
        var actualResult = _targetFunc.Invoke(_result);
        
        Xunit.Assert.Equal(expectedValue, actualResult);
    }
}