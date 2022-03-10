using Moq;

namespace XpressTest;

public interface IMockDependencyAsserterComposer<TSut>
{
    IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        Mock<TDependency> dependencyMock,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
            where TDependency : class;

    IVoidAsserter<TSut> Compose<TDependency>(
        Mock<TDependency> dependencyMock,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
        where TDependency : class;
    
    IVoidAsserter<TSut> Compose<TDependency>(
        Mock<TDependency> dependencyMock,
        System.Action<TSut> func,
        IArrangement arrangement
    )
        where TDependency : class;
}
