namespace XpressTest;

public class ResultProvider<TSut, TResult> : IResultProvider<TResult>
{
    private readonly Func<TSut, TResult> _func;

    public ResultProvider(
        Func<TSut, TResult> func
        )
    {
        _func = func;
    }

    public TResult Get()
    {
        var sut = Activator.CreateInstance<TSut>();

        return _func.Invoke(sut);
    }
}
