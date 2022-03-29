namespace XpressTest;

public interface IAsserterCreator<TSut>
{
    IVoidAsserter<TSut> CreateVoidAsserter(System.Action<TSut> action);
    
    IVoidAsserter<TSut> CreateVoidAsserter(System.Action<IAction<TSut>> action);
    
    IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<IAction<TSut>, TResult> func);
    
    IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(Func<TSut, TResult> func);
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<IAction<TSut>, Task<TResult>> func);
    
    Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(Func<TSut, Task<TResult>> func);
}