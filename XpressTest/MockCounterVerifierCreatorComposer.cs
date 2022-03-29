using Moq;

namespace XpressTest;

public class MockCounterVerifierCreatorComposer<TAsserter>
    :
        IMockCounterVerifierCreatorComposer<TAsserter>
{
    private readonly IArrangement _arrangement;

    public MockCounterVerifierCreatorComposer(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public IMockCounterVerifierCreator<TMock, TAsserter> Compose<TMock>(TAsserter asserter)
        where TMock : class
    {
        var mock = _arrangement.GetMock<TMock>();
        
        var mockCallCountVerifierCreator = new MockCallCountVerifierCreator<TMock>(
            mock
        );
        
        
        
        var resultMockCallVerifierCreator = new ResultMockCallVerifierCreator<TMock, TAsserter>(
            mockCallCountVerifierCreator,
            asserter
        );
        
        var resultMockCounterVerifierCreator = new ResultMockCounterVerifierCreator<TMock, TAsserter>(
            resultMockCallVerifierCreator
        );

        
        
        var arrangementResultMockCallVerifierCreator =
            new ArrangementResultMockCallVerifierCreator<TMock, TAsserter>(
                mockCallCountVerifierCreator,
                _arrangement
            );
        
        var arrangementResultMockCounterVerifierCreator =
            new ArrangementResultMockCounterVerifierCreator<TMock, TAsserter>(
                arrangementResultMockCallVerifierCreator
            );

        

        var voidMockCallVerifierCreator = new VoidMockCallVerifierCreator<TMock, TAsserter>(
            mockCallCountVerifierCreator,
            asserter
            );
        
        var voidMockCounterVerifierCreator = new VoidMockCounterVerifierCreator<TMock, TAsserter>(
            voidMockCallVerifierCreator
            );
        
        
        
        var arrangementVoidMockCallVerifierCreator =
            new ArrangementVoidMockCallVerifierCreator<TMock, TAsserter>(
                mockCallCountVerifierCreator,
                _arrangement
            );
        
        var arrangementVoidMockCounterVerifierCreator =
            new ArrangementVoidMockCounterVerifierCreator<TMock, TAsserter>(
                arrangementVoidMockCallVerifierCreator
            );
        
        
        
        return new MockCounterVerifierCreator<TMock, TAsserter>(
            resultMockCounterVerifierCreator,
            arrangementResultMockCounterVerifierCreator,
            voidMockCounterVerifierCreator,
            arrangementVoidMockCounterVerifierCreator
        );
    }

    public IMockCounterVerifierCreator<TMock, TAsserter> Compose<TMock>(
        Mock<TMock> mock,
        TAsserter asserter
        )
        where TMock : class
    {
        var mockCallCountVerifierCreator = new MockCallCountVerifierCreator<TMock>(
            mock
        );
        
        
        
        var resultMockCallVerifierCreator = new ResultMockCallVerifierCreator<TMock, TAsserter>(
            mockCallCountVerifierCreator,
            asserter
        );
        
        var resultMockCounterVerifierCreator = new ResultMockCounterVerifierCreator<TMock, TAsserter>(
            resultMockCallVerifierCreator
        );

        
        
        var arrangementResultMockCallVerifierCreator =
            new ArrangementResultMockCallVerifierCreator<TMock, TAsserter>(
                mockCallCountVerifierCreator,
                _arrangement
            );
        
        var arrangementResultMockCounterVerifierCreator =
            new ArrangementResultMockCounterVerifierCreator<TMock, TAsserter>(
                arrangementResultMockCallVerifierCreator
            );

        

        var voidMockCallVerifierCreator = new VoidMockCallVerifierCreator<TMock, TAsserter>(
            mockCallCountVerifierCreator,
            asserter
            );
        
        var voidMockCounterVerifierCreator = new VoidMockCounterVerifierCreator<TMock, TAsserter>(
            voidMockCallVerifierCreator
            );
        
        
        
        var arrangementVoidMockCallVerifierCreator =
            new ArrangementVoidMockCallVerifierCreator<TMock, TAsserter>(
                mockCallCountVerifierCreator,
                _arrangement
            );
        
        var arrangementVoidMockCounterVerifierCreator =
            new ArrangementVoidMockCounterVerifierCreator<TMock, TAsserter>(
                arrangementVoidMockCallVerifierCreator
            );
        
        
        
        return new MockCounterVerifierCreator<TMock, TAsserter>(
            resultMockCounterVerifierCreator,
            arrangementResultMockCounterVerifierCreator,
            voidMockCounterVerifierCreator,
            arrangementVoidMockCounterVerifierCreator
        );
    }
}