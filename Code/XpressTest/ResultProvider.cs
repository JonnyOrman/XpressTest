using System.Linq.Expressions;

namespace XpressTest;

public class ResultProvider<TSut, TResult>
    :
        IResultProvider<TResult>
{
    private readonly TSut _sut;
    private readonly Expression<Func<TSut, TResult>> _func;

    public ResultProvider(
        TSut sut,
        Expression<Func<TSut, TResult>> func
        )
    {
        _sut = sut;
        _func = func;
    }

    public TResult Get()
    {
        return _func.Compile().Invoke(_sut);
    }
}
