namespace XpressTest;

public interface IAsyncResultPropertyTargeter<TResult>
:
    IResultValueAsserter<TResult>,
    IArrangementResultValueAsserter<TResult>,
    INullResultAsserter
{
}