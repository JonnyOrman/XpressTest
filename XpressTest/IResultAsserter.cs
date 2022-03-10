namespace XpressTest;

public interface IResultAsserter<TSut, TResult> : IResultPropertyTargeter<TResult>
{
    void Then(System.Action<IAssertion<TResult>> assertion);

    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class;

    void ThenTheResultShouldBeNull();
}