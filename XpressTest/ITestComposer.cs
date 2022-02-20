using Moq;

namespace XpressTest;

public interface ITestComposer<TSut>
{
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
    );

    IMockDependencyBuilder<TSut, TNewDependency> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
    )
        where TNewDependency : class;

    IAsserter<System.Action<IAssertion<TSut, TResult>>> ComposeMockAsserter<TResult, TDependency>(
        Mock<TDependency> dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
            where TDependency : class;

    IAsserter<System.Action<IArrangement>> ComposeMockAsserter<TDependency>(
        Mock<TDependency> dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
    )
        where TDependency : class;

    IAsserter<System.Action<IAssertion<TSut, TResult>>> ComposeAsserter<TResult, TDependency>(
        TDependency dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
    );

    IAsserter<System.Action<IArrangement>> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
    );

    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> dependencyMock,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
        where TDependency : class
        where TNewDependency : class;
}