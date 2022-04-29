namespace XpressTest;

public class AsserterCreator<TSut> : IAsserterCreator<TSut>
{
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private readonly IResultAsserterCreator<TSut> _resultAsserterCreator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public AsserterCreator(
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IResultAsserterCreator<TSut> resultAsserterCreator,
        ISutAsserterCreator<TSut> sutAsserterCreator
        )
    {
        _voidAsserterCreator = voidAsserterCreator;
        _resultAsserterCreator = resultAsserterCreator;
        _sutAsserterCreator = sutAsserterCreator;
    }

    public IVoidAsserter<TSut> CreateVoidAsserter(Action<TSut> action)
    {
        return _voidAsserterCreator.Create(action);
    }

    public IVoidAsserter<TSut> CreateVoidAsserter(Action<ISutArrangement<TSut>> action)
    {
        return _voidAsserterCreator.Create(action);
    }

    public IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<ISutArrangement<TSut>, TResult> func)
    {
        return _resultAsserterCreator.Create(func);
    }

    public IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<TSut, TResult> func)
    {
        return _resultAsserterCreator.Create(func);
    }

    public IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func)
    {
        return _resultAsserterCreator.Create(func);
    }

    public Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<ISutArrangement<TSut>, Task<TResult>> func)
    {
        return _resultAsserterCreator.CreateAsync(func);
    }

    public Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<TSut, Task<TResult>> func)
    {
        return _resultAsserterCreator.CreateAsync(func);
    }

    public ISutPropertyTargeter<TSut> CreateSutAsserter()
    {
        return _sutAsserterCreator.Create();
    }
}