namespace XpressTest;

public interface IVoidAsserter<TSut, TAssertion>
{
    ITester Then(TAssertion assertion);

    IVoidMockVerifier<TSut, TAssertion, TMock> Then<TMock>();
}