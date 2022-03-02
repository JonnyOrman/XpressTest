namespace XpressTest;

public interface IVoidMockCounterVerifier<TSut, TAssertion>
{
    IVoidAsserter<TSut, TAssertion> Once();
}