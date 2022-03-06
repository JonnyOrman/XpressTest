namespace XpressTest;

public class MockCallVerifier<TAsserter> : IMockCallVerifier<TAsserter>
{
    private readonly IMockCallCountVerifier _mockCallCountVerifier;

    private readonly TAsserter _asserter;

    public MockCallVerifier(
        IMockCallCountVerifier mockCallCountVerifier,
        TAsserter asserter
        )
    {
        _mockCallCountVerifier = mockCallCountVerifier;
        _asserter = asserter;
    }

    public TAsserter Verify(int expectedNumberOfCalls)
    {
        _mockCallCountVerifier.Verify(expectedNumberOfCalls);

        return _asserter;
    }
}