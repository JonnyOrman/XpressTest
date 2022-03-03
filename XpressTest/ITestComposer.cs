using Moq;

namespace XpressTest;

public interface ITestComposer<TSut>
{
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name
    )
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency
    )
        where TNewDependency : class;

    IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult, TDependency>(
        Mock<TDependency> dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
            where TDependency : class;

    IVoidAsserter<TSut> ComposeMockAsserter<TDependency>(
        Mock<TDependency> dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
    )
        where TDependency : class;

    IResultAsserter<TSut, TResult> ComposeAsserter<TResult, TDependency>(
        TDependency dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
    );

    IVoidAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
    )
        where TDependency : class;

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
        Mock<TObject> mock
    )
        where TNewDependency : class
        where TObject : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedObject<TObject> namedObject
        )
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        TObject obj
    )
        where TNewDependency : class;

    IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency, TObject>(
        INamedObject<TObject> oldNamedObject,
        INamedObject<TNewDependency> newNamedObject
        );

    IObjectBuilder<TSut> StartNewObjectBuilder<TOldObject, TNewObject>(
        TOldObject oldObject,
        TNewObject newObject
    );

    IArrangement Arrangement { get; }
    
    IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject, TObject>(Mock<TObject> mock)
        where TNewObject : class
        where TObject : class;
}