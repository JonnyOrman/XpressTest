using Moq;

namespace XpressTest;

public interface IAsyncResultAsserter<TSut, TResult>
    :
        IAsyncResultPropertyTargeter<TResult>
{
    IAsyncResultMockVerifier<TSut, TResult, TMock> ThenAsync<TMock>()
        where TMock : class;
    
    void ThenAsync(
        System.Action<IAssertion<TResult>> action
        );
    
    IAsyncResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class;
    
    IAsyncResultMockVerifier<TSut, TResult, TMock> ThenAsync<TMock>(
        Mock<TMock> mock
        )
        where TMock : class;
}