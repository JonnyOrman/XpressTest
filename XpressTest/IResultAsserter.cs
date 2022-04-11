namespace XpressTest;

public interface IResultAsserter<TSut, TResult>
    :
        IResultPropertyTargeter<TSut, TResult>,
        INullResultAsserter,
        INotNullResultAsserter,
        IThenResultActionAsserter<TResult>
{
    IResultMockVerifier<TSut, TResult, TMock> ThenThe<TMock>()
        where TMock : class;
    
    IResultMockVerifier<TSut, TResult, TMock> ThenThe<TMock>(string name)
        where TMock : class;
    
    IResultMockVerifier<TSut, TResult, TMock> Then<TMock>(Moq.Mock<TMock> mock)
        where TMock : class;
}