namespace XpressTest;

public class ResultPropertyNullAsserter<TSut, TResult>
    :
        IResultPropertyNullAsserter<TSut, TResult>
{
    private readonly IResultPropertyNullComparer _resultPropertyNullComparer;

    private readonly IResultPropertyTargeter<TSut, TResult> _resultPropertyTargeter;

    public ResultPropertyNullAsserter(
        IResultPropertyNullComparer resultPropertyNullComparer,
        IResultPropertyTargeter<TSut, TResult> resultPropertyTargeter
        )
    {
        _resultPropertyNullComparer = resultPropertyNullComparer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }

    public IResultPropertyTargeter<TSut, TResult> Assert()
    {
        _resultPropertyNullComparer.Compare();

        return _resultPropertyTargeter;
    }
}