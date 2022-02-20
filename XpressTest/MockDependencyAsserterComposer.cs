using Moq;

namespace XpressTest;

public class MockDependencyAsserterComposer<TSut> : IMockDependencyAsserterComposer<TSut>
{
    private readonly IAsserterComposer<TSut> _asserterComposer;

    public MockDependencyAsserterComposer(
        IAsserterComposer<TSut> asserterComposer
        )
    {
        _asserterComposer = asserterComposer;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> Compose<TResult, TDependency>(
        Mock<TDependency> dependencyMock,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        ) where TDependency : class
    {
        var dependency = new MockDependency<TDependency>(dependencyMock);

        return _asserterComposer.Compose<TResult, TDependency>(
            dependency,
            func,
            arrangement
        );
    }

    public IAsserter<System.Action<IArrangement>> Compose<TDependency>(
        Mock<TDependency> dependencyMock,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        ) where TDependency : class
    {
        var dependency = new MockDependency<TDependency>(dependencyMock);

        return _asserterComposer.Compose<TDependency>(
            dependency,
            func,
            arrangement
        );
    }
}
