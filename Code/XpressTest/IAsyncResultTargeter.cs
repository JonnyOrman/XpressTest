namespace XpressTest;

public interface IAsyncResultTargeter<TSut, TResult>
:
    IResultValueAsserter<TResult>,
    IArrangementResultValueAsserter<TSut, TResult>,
    INullResultAsserter
{
}