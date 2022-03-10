namespace XpressTest;

public class ResultPropertyNullComparer<TResult, TProperty>
    :
        IResultPropertyNullComparer
{
    private readonly TResult _result;
    private readonly Func<TResult, TProperty> _targetFunc;

    public ResultPropertyNullComparer(
        TResult result,
        Func<TResult, TProperty> targetFunc
        )
    {
        _result = result;
        _targetFunc = targetFunc;
    }
    
    public void Compare()
    {
        var actualResult = _targetFunc.Invoke(_result);
        
        Xunit.Assert.Null(actualResult);
    }
}