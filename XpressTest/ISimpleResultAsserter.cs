namespace XpressTest;

public interface ISimpleResultAsserter<TResult>
    :
        IExceptionAsserter,
        IResultValueAsserter<TResult>
{
    void Then(System.Action<IAssertion<TResult>> assertion);
}