namespace XpressTest;

public class VoidMockVerifierCreator<TSut>
    :
        IVoidMockVerifierCreator<TSut>
    where TSut : class
{
    private readonly IMockCounterVerifierCreatorComposer<IVoidAsserter<TSut>> _mockCounterVerifierCreatorComposer;

    public VoidMockVerifierCreator(
        IMockCounterVerifierCreatorComposer<IVoidAsserter<TSut>> mockCounterVerifierCreatorComposer
        )
    {
        _mockCounterVerifierCreatorComposer = mockCounterVerifierCreatorComposer;
    }
    
    public IVoidMockVerifier<TSut, TMock> Create<TMock>(
        IVoidAsserter<TSut> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _mockCounterVerifierCreatorComposer.Compose<TMock>(
            asserter
            );  
        
        return new VoidMockVerifier<TSut, TMock>(
            mockCounterVerifierCreator,
            asserter
        );
    }
}