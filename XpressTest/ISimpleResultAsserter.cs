namespace XpressTest;

public interface ISimpleResultAsserter<TResult>
    :
        IExceptionAsserter
{
    void Then(System.Action<IAssertion<TResult>> assertion);
}