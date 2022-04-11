namespace XpressTest;

public interface IMockCounterVerifierCreatorComposer<TAsserter>
{
    IMockCounterVerifierCreator<TMock, TAsserter> Compose<TMock>(
        TAsserter asserter
        )
        where TMock : class;
    
    IMockCounterVerifierCreator<TMock, TAsserter> Compose<TMock>(
        IMock<TMock> mock,
        TAsserter asserter
    )
        where TMock : class;
}