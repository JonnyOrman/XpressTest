namespace XpressTest;

public interface IResultAsserterCreator<TSut>
{
    IResultAsserter<TSut, TResult> Create<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
        );
    
    IResultAsserter<TSut, TResult> Create<TResult>(
        Func<TSut, TResult> func
    );
    
    IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<TSut, Task<TResult>> func
    );
}