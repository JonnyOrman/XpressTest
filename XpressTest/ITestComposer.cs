using Moq;

namespace XpressTest;

public interface ITestComposer<TSut>
{
    IValueDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency
    );
    
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name
    )
        where TNewDependency : class;
    
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        string dependencyName,
        TNewDependency newDependency,
        string newDependencyName
    )
        where TNewDependency : class;

    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> mock,
        TNewDependency newDependency,
        string newDependencyName
    )
        where TDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency
    )
        where TNewDependency : class;
    
    IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> dependency
    )
        where TDependency : class;

    IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult, TDependency>(
        Mock<TDependency> dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
            where TDependency : class;

    IVoidAsserter<TSut> ComposeMockAsserter<TDependency>(
        Mock<TDependency> dependency,
        System.Action<TSut> action,
        IArrangement arrangement
    )
        where TDependency : class;
    
    IVoidAsserter<TSut> ComposeMockAsserter<TDependency>(
        Mock<TDependency> dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
    )
        where TDependency : class;

    ISutAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        IArrangement arrangement
    );
    
    IResultAsserter<TSut, TResult> ComposeAsserter<TResult, TDependency>(
        TDependency dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
    );

    IVoidAsserter<TSut> ComposeAsserter(
        System.Action<TSut> func,
        IArrangement arrangement
    );
    
    IVoidAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
    )
        where TDependency : class;
    
    IVoidAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<TSut> func,
        IArrangement arrangement
    );

    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        TDependency currentDependency,
        string currentDependencyName
    )
        where TNewDependency : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> mock
        )
        where TDependency : class
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;

    IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        INamedObject<TNewDependency> newNamedObject
        );

    IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
    );
    
    IArrangement Arrangement { get; }

    IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class;

    TNamedObject GetObject<TNamedObject>(string objectName);
    
    IObjectBuilder<TSut> StartNewExistingObjectBuilder(
        ITestComposer<TSut> testComposer
        );
    
    IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>();
    
    IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>(
        Mock<TObject> obj,
        TNewDependency newDependency
    )
        where TObject : class;
}