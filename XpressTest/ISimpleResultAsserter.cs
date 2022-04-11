namespace XpressTest;

public interface ISimpleResultAsserter<TResult>
    :
        IExceptionAsserter,
        IResultValueAsserter<TResult>,
        IThenResultActionAsserter<TResult>
{
}