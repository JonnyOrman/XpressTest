namespace XpressTest;

public interface IResultMockVerifierCreator<TSut, TSutResult>
{
    IAsyncResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IAsyncResultAsserter<TSut, TSutResult> asserter
        )
        where TMock : class;

    IAsyncResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IMock<TMock> mock,
        IAsyncResultAsserter<TSut, TSutResult> asserter
    )
        where TMock : class;

    IResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IMock<TMock> mock,
        IResultAsserter<TSut, TSutResult> asserter
    )
        where TMock : class;
}