namespace XpressTest;

public class ResultMockVerifierCreator<TSut, TSutResult>
    :
        IResultMockVerifierCreator<TSut, TSutResult>
    where TSut : class
{
    private readonly IMockCounterVerifierCreatorComposer<IResultAsserter<TSut, TSutResult>> _mockCounterVerifierCreatorComposer;

    public ResultMockVerifierCreator(
        IMockCounterVerifierCreatorComposer<IResultAsserter<TSut, TSutResult>> mockCounterVerifierCreatorComposer
        )
    {
        _mockCounterVerifierCreatorComposer = mockCounterVerifierCreatorComposer;
    }
    
    public IResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IResultAsserter<TSut, TSutResult> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _mockCounterVerifierCreatorComposer.Compose<TMock>(
            asserter
            );
        
        return new ResultMockVerifier<TSut, TSutResult, TMock>(
            mockCounterVerifierCreator,
            asserter
            );
    }
}