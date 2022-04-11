namespace XpressTest;

public interface IAsyncResultPropertyTargeter<TSut, TResult>
:
    IResultValueAsserter<TResult>,
    IArrangementResultValueAsserter<TSut, TResult>,
    INullResultAsserter
{
}