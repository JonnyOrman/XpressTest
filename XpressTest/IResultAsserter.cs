using Moq;

namespace XpressTest;

public interface IResultAsserter<TSut, TResult>
    :
        IResultPropertyTargeter<TResult>,
        INullResultAsserter,
        INotNullResultAsserter
{
    void Then(System.Action<IAssertion<TResult>> action);

    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class;
    
    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>(string name)
        where TMock : class;
    
    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>(Mock<TMock> mock)
        where TMock : class;
}