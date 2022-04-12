namespace XpressTest;

public interface IVoidMockVerifierCreator<TSut>
{
    IVoidMockVerifier<TSut, TMock> Create<TMock>(
        IVoidAsserter<TSut> asserter
        )
        where TMock : class;
    
    IVoidMockVerifier<TSut, TMock> Create<TMock>(
        IMock<TMock> mock,
        IVoidAsserter<TSut> asserter
    )
        where TMock : class;
}