using Moq;

namespace XpressTest;

public interface IResultAsserter<TSut, TResult>
    :
        IExceptionAsserter,
        IResultPropertyTargeter<TResult>
{
    void Then(System.Action<IAssertion<TResult>> action);

    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class;
    
    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>(string name)
        where TMock : class;
    
    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>(Mock<TMock> mock)
        where TMock : class;

    void ThenTheResultShouldBeNull();
}