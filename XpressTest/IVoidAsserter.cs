using Moq;

namespace XpressTest;

public interface IVoidAsserter<TSut>
{
    IVoidMockVerifier<TSut, TMock> Then<TMock>()
        where TMock : class;
    
    IVoidMockVerifier<TSut, TMock> Then<TMock>(
        Mock<TMock> mock
        )
        where TMock : class;
    
    void Then(System.Action<IAssertion> assertion);
    
    IVoidAsserter<TSut> ThenWhenIt(System.Action<IAction<TSut>> action);
    
    IResultAsserter<TSut, TResult> ThenWhenIt<TResult>(Func<TSut, TResult> func);
}