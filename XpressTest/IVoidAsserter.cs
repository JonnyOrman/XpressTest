namespace XpressTest;

public interface IVoidAsserter<TSut>
{
    IVoidMockVerifier<TSut, TMock> ThenThe<TMock>()
        where TMock : class;
    
    IVoidMockVerifier<TSut, TMock> Then<TMock>(
        Moq.Mock<TMock> mock
        )
        where TMock : class;
    
    void Then(Action<ISutArrangement<TSut>> assertion);
    
    IVoidAsserter<TSut> ThenWhenIt(Action<ISutArrangement<TSut>> action);
    
    IResultAsserter<TSut, TResult> ThenWhenIt<TResult>(Func<TSut, TResult> func);
}