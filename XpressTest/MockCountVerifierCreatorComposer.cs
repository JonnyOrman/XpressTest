namespace XpressTest;

public class MockCountVerifierCreatorComposer<TSut, TAsserter>
    :
        IMockCountVerifierCreatorComposer<TAsserter>
{
    private readonly ISutArrangement<TSut> _arrangement;

    public MockCountVerifierCreatorComposer(
        ISutArrangement<TSut> arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public IMockCountVerifierCreator<TMock, TAsserter> Compose<TMock>(TAsserter asserter)
        where TMock : class
    {
        var mock = _arrangement.GetTheMock<TMock>();

        return Compose(
            mock,
            asserter
        );
    }

    public IMockCountVerifierCreator<TMock, TAsserter> Compose<TMock>(
        IMock<TMock> mock,
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
        
        var resultMockCounterVerifierCreator = new ResultMockCountVerifierCreator<TMock, TAsserter>(
            resultMockCallVerifierCreator
        );

        var arrangementResultMockCallVerifierCreator =
            new ArrangementResultMockCallVerifierCreator<TMock, TAsserter>(
                mockCallCountVerifierCreator,
                _arrangement
            );
        
        var arrangementResultMockCounterVerifierCreator =
            new ArrangementResultMockCountVerifierCreator<TMock, TAsserter>(
                arrangementResultMockCallVerifierCreator
            );

        var voidMockCallVerifierCreator = new VoidMockCallVerifierCreator<TMock, TAsserter>(
            mockCallCountVerifierCreator,
            asserter
            );
        
        var voidMockCounterVerifierCreator = new VoidMockCountVerifierCreator<TMock, TAsserter>(
            voidMockCallVerifierCreator
            );
        
        var arrangementVoidMockCallVerifierCreator =
            new ArrangementVoidMockCallVerifierCreator<TMock, TAsserter>(
                mockCallCountVerifierCreator,
                _arrangement
            );
        
        var arrangementVoidMockCounterVerifierCreator =
            new ArrangementVoidMockCountVerifierCreator<TMock, TAsserter>(
                arrangementVoidMockCallVerifierCreator
            );
        
        return new MockCountVerifierCreator<TMock, TAsserter>(
            resultMockCounterVerifierCreator,
            arrangementResultMockCounterVerifierCreator,
            voidMockCounterVerifierCreator,
            arrangementVoidMockCounterVerifierCreator
        );
    }
}