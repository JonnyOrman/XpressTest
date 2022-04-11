namespace XpressTest;

public interface IAsyncResultAsserter<TSut, TResult>
    :
        IAsyncResultPropertyTargeter<TSut, TResult>
{
    IAsyncResultMockVerifier<TSut, TResult, TMock> ThenTheAsync<TMock>()
        where TMock : class;
    
    void ThenAsync(
        Action<IResultAssertion<TResult>> action
        );
    
    IAsyncResultMockVerifier<TSut, TResult, TMock> ThenThe<TMock>()
        where TMock : class;
    
    IAsyncResultMockVerifier<TSut, TResult, TMock> ThenAsync<TMock>(
        Moq.Mock<TMock> mock
        )
        where TMock : class;
}