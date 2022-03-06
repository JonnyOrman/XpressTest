namespace XpressTest;

public class MockCounterVerifier<TAsserter>
    :
        IMockCounterVerifier<TAsserter>
{
    private readonly IMockCallVerifier<TAsserter> _resultMockVerifier;

    public MockCounterVerifier(
        IMockCallVerifier<TAsserter> resultMockVerifier
        )
    {
        _resultMockVerifier = resultMockVerifier;
    }
    
    public TAsserter Once()
    {
        return _resultMockVerifier.Verify(1);
    }

    public TAsserter Never()
    {
        return _resultMockVerifier.Verify(0);
    }
}