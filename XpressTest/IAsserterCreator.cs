namespace XpressTest;

public interface IAsserterCreator<TSut>
{
    IVoidAsserter<TSut> CreateVoidAsserter(Action<TSut> action);
    
    IVoidAsserter<TSut> CreateVoidAsserter(Action<ISutArrangement<TSut>> action);
    
    IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<ISutArrangement<TSut>, TResult> func);
    
    IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<TSut, TResult> func);
    
    IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<IReadArrangement, Func<TSut, TResult>> func);
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<ISutArrangement<TSut>, Task<TResult>> func);
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<TSut, Task<TResult>> func);
    
    ISutPropertyTargeter<TSut> CreateSutAsserter();
}