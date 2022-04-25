namespace XpressTest;

public class MockCountVerifier<TAsserter>
    :
        IMockCountVerifier<TAsserter>
{
    private readonly IMockCallVerifier<TAsserter> _resultMockVerifier;

    public MockCountVerifier(
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