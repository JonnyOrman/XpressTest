namespace XpressTest;

public interface IMockCallVerifier<TAsserter>
{
    TAsserter Verify(int expectedNumberOfCalls);
}