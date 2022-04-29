namespace XpressTest;

public class ResultProvider<TSut, TResult>
    :
        IResultProvider<TResult>
{
    private readonly TSut _sut;
    private readonly Func<TSut, TResult> _func;

    public ResultProvider(
        TSut sut,
        Func<TSut, TResult> func
        )
    {
        _sut = sut;
        _func = func;
    }

    public TResult Get()
    {
        return _func.Invoke(_sut);
    }
}
