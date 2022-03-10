namespace XpressTest;

public class ResultPropertyNullAsserter<TResult>
    :
        IResultPropertyNullAsserter<TResult>
{
    private readonly IResultPropertyNullComparer _resultPropertyNullComparer;

    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;
    
    public ResultPropertyNullAsserter(
        IResultPropertyNullComparer resultPropertyNullComparer,
        IResultPropertyTargeter<TResult>  resultPropertyTargeter
        )
    {
        _resultPropertyNullComparer = resultPropertyNullComparer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public IResultPropertyTargeter<TResult> Assert()
    {
        _resultPropertyNullComparer.Compare();
        
        return _resultPropertyTargeter;
    }
}