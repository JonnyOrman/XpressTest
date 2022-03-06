namespace XpressTest;

public interface IResultMockVerifierCreator<TSut, TSutResult>
{
    IResultMockVerifier<TSut, TSutResult, TMock> Create<TMock>(
        IResultAsserter<TSut, TSutResult> asserter
        )
        where TMock : class;
}