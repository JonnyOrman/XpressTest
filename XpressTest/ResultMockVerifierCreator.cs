namespace XpressTest;

public class ResultMockVerifierCreator<TSut, TSutResult>
    :
        IResultMockVerifierCreator<TSut, TSutResult>
    where TSut : class
{
    private readonly IMockCountVerifierCreatorComposer<IResultAsserter<TSut, TSutResult>> _mockCounterVerifierCreatorComposer;
    private readonly IMockCountVerifierCreatorComposer<IAsyncResultAsserter<TSut, TSutResult>> _asyncMockCounterVerifierCreatorComposer;

    public ResultMockVerifierCreator(
        IMockCountVerifierCreatorComposer<IResultAsserter<TSut, TSutResult>> mockCounterVerifierCreatorComposer,
        IMockCountVerifierCreatorComposer<IAsyncResultAsserter<TSut, TSutResult>> asyncMockCounterVerifierCreatorComposer
        )
    {
        _mockCounterVerifierCreatorComposer = mockCounterVerifierCreatorComposer;
        _asyncMockCounterVerifierCreatorComposer = asyncMockCounterVerifierCreatorComposer;
    }
    
    public IAsyncResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IAsyncResultAsserter<TSut, TSutResult> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _asyncMockCounterVerifierCreatorComposer.Compose<TMock>(
            asserter
        );
        
        return new AsyncResultMockVerifier<TSut, TSutResult, TMock>(
            mockCounterVerifierCreator,
            asserter
        );
    }

    public IAsyncResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IMock<TMock> mock,
        IAsyncResultAsserter<TSut, TSutResult> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _asyncMockCounterVerifierCreatorComposer.Compose(
            mock,
            asserter
        );
        
        return new AsyncResultMockVerifier<TSut, TSutResult, TMock>(
            mockCounterVerifierCreator,
            asserter
        );
    }

    public IResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IMock<TMock> mock,
        IResultAsserter<TSut, TSutResult> asserter
        )
        where TMock : class
    {
        var mockCounterVerifierCreator = _mockCounterVerifierCreatorComposer.Compose(
            mock,
            asserter
        );
        
        return new ResultMockVerifier<TSut, TSutResult, TMock>(
            mockCounterVerifierCreator,
            asserter
        );
    }
}