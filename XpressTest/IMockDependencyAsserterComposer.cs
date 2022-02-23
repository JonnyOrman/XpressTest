using Moq;

namespace XpressTest;

public interface IMockDependencyAsserterComposer<TSut>
{
    IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> Compose<TResult, TDependency>(
        Mock<TDependency> dependencyMock,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
            where TDependency : class;

    IAsserter<System.Action<IArrangement>> Compose<TDependency>(
        Mock<TDependency> dependencyMock,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
        where TDependency : class;
}
