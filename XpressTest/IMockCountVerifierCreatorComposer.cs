namespace XpressTest;

public interface IMockCountVerifierCreatorComposer<TAsserter>
{
    IMockCountVerifierCreator<TMock, TAsserter> Compose<TMock>(
        TAsserter asserter
        )
        where TMock : class;
    
    IMockCountVerifierCreator<TMock, TAsserter> Compose<TMock>(
        IMock<TMock> mock,
        TAsserter asserter
    )
        where TMock : class;
}