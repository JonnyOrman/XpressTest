using Moq;

namespace XpressTest;

public class ResultMockVerifierCreator<TSut, TSutResult>
    :
        IResultMockVerifierCreator<TSut, TSutResult>
    where TSut : class
{
    private readonly IMockCounterVerifierCreatorComposer<IResultAsserter<TSut, TSutResult>> _mockCounterVerifierCreatorComposer;
    private readonly IMockCounterVerifierCreatorComposer<IAsyncResultAsserter<TSut, TSutResult>> _asyncMockCounterVerifierCreatorComposer;

    public ResultMockVerifierCreator(
        IMockCounterVerifierCreatorComposer<IResultAsserter<TSut, TSutResult>> mockCounterVerifierCreatorComposer,
        IMockCounterVerifierCreatorComposer<IAsyncResultAsserter<TSut, TSutResult>> asyncMockCounterVerifierCreatorComposer
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
        Mock<TMock> mock,
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
        Mock<TMock> mock,
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