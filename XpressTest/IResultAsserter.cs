namespace XpressTest;

public interface IResultAsserter<TSut, TResult> : IResultPropertyTargeter<TResult>
{
    ITester Then(System.Action<IAssertion<TSut, TResult>> assertion);

    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class;

    void ThenTheResultShouldBeNull();
}