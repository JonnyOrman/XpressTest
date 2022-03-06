namespace XpressTest;

public interface IMockCallCountVerifier
{
    void Verify(int expectedNumberOfCalls);
}