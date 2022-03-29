namespace XpressTest;

public class AsserterCreator<TSut> : IAsserterCreator<TSut>
{
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private readonly IResultAsserterCreator<TSut> _resultAsserterCreator;

    public AsserterCreator(
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IResultAsserterCreator<TSut> resultAsserterCreator
        )
    {
        _voidAsserterCreator = voidAsserterCreator;
        _resultAsserterCreator = resultAsserterCreator;
    }
    
    public IVoidAsserter<TSut> CreateVoidAsserter(System.Action<TSut> action)
    {
        return _voidAsserterCreator.Create(action);
    }

    public IVoidAsserter<TSut> CreateVoidAsserter(System.Action<IAction<TSut>> action)
    {
        return _voidAsserterCreator.Create(action);
    }

    public IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return _resultAsserterCreator.Create(func);
    }

    public IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<TSut, TResult> func)
    {
        return _resultAsserterCreator.Create(func);
    }

    public Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<IAction<TSut>, Task<TResult>> func)
    {
        return _resultAsserterCreator.CreateAsync(func);
    }

    public Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<TSut, Task<TResult>> func)
    {
        return _resultAsserterCreator.CreateAsync(func);
    }
}