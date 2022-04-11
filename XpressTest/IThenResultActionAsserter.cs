namespace XpressTest;

public interface IThenResultActionAsserter<TResult>
{
    void Then(Action<IResultAssertion<TResult>> assertion);
}