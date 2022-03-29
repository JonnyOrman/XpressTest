namespace XpressTest;

public interface IResultAsserterCreator<TSut>
{
    IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IAction<TSut>, TResult> func
        );
    
    IResultAsserter<TSut, TResult> Create<TResult>(
        Func<TSut, TResult> func
    );
    
    IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IArrangement, Func<TSut, TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<TSut, Task<TResult>> func
    );
}