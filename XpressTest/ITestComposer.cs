using Moq;

namespace XpressTest;

public interface ITestComposer<TSut>
{
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name
    );

    IMockDependencyBuilder<TSut, TNewDependency> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency
    )
        where TNewDependency : class;

    IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> ComposeMockAsserter<TResult, TDependency>(
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

    IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> ComposeAsserter<TResult, TDependency>(
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
        Mock<TDependency> mock
        )
        where TDependency : class
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedMock<TObject> namedMock
        )
            where TNewDependency : class
            where TObject : class;

    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedObject<TObject> namedObject
        )
        where TNewDependency : class;

    IObjectBuilder<TSut> StartNewObjectBuilder<TNewDependency, TObject>(
        INamedObject<TObject> oldNamedObject,
        INamedObject<TNewDependency> newNamedObject
        );

    IArrangement Arrangement { get; }
}