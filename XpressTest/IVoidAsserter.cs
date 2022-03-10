namespace XpressTest;

public interface IVoidAsserter<TSut>
{
    IVoidMockVerifier<TSut, TMock> Then<TMock>()
        where TMock : class;
    
    void Then(System.Action<IAssertion> assertion);
}