namespace XpressTest;

public interface IVoidMockCounterVerifier<TSut>
{
    IVoidAsserter<TSut> Once();

    IVoidAsserter<TSut> Never();
}