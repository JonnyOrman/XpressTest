namespace XpressTest;

public class VoidMockVerifierCreator<TSut>
    :
        IVoidMockVerifierCreator<TSut>
    where TSut : class
{
    private readonly IMockCountVerifierCreatorComposer<IVoidAsserter<TSut>> _mockCountVerifierCreatorComposer;

    public VoidMockVerifierCreator(
        IMockCountVerifierCreatorComposer<IVoidAsserter<TSut>> mockCountVerifierCreatorComposer
        )
    {
        _mockCountVerifierCreatorComposer = mockCountVerifierCreatorComposer;
    }

    public IVoidMockVerifier<TSut, TMock> Create<TMock>(
        IVoidAsserter<TSut> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _mockCountVerifierCreatorComposer.Compose<TMock>(
            asserter
            );

        return new VoidMockVerifier<TSut, TMock>(
            mockCounterVerifierCreator,
            asserter
        );
    }

    public IVoidMockVerifier<TSut, TMock> Create<TMock>(
        IMock<TMock> mock,
        IVoidAsserter<TSut> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _mockCountVerifierCreatorComposer.Compose(
            mock,
            asserter
        );

        return new VoidMockVerifier<TSut, TMock>(
            mockCounterVerifierCreator,
            asserter
        );
    }
}