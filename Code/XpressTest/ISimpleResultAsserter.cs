namespace XpressTest;

public interface ISimpleResultAsserter<TResult>
    :
        IExceptionAsserter,
        IResultValueAsserter<TResult>,
        IThenActionAsserter<IResultAssertion<TResult>>
{
}