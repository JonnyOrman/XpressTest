namespace XpressTest;

public interface IVoidAsserter<TSut>
:
    IAsserter<ISutArrangement<TSut>>,
    IThenWhenItAsserter<TSut>
{
    IVoidMockVerifier<TSut, TMock> ThenThe<TMock>()
        where TMock : class;

    IVoidMockVerifier<TSut, TMock> ThenThe<TMock>(
        string name
        )
        where TMock : class;

    IVoidMockVerifier<TSut, TMock> Then<TMock>(
        Moq.Mock<TMock> mock
        )
        where TMock : class;
}