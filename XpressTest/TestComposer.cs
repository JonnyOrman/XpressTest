using Moq;

namespace XpressTest;

public class TestComposer<TSut> : ITestComposer<TSut>
    where TSut : class
{
    private readonly IMockDependencyAsserterComposer<TSut> _mockDependencyAsserterComposer;
    private readonly IDependencyAsserterComposer<TSut> _dependencyAsserterComposer;
    private readonly IDependencyBuilderComposer<TSut> _dependencyBuilderComposer;
    private readonly IMockDependencyBuilderComposer<TSut> _mockDependencyBuilderComposer;
    private readonly IResultAsserterComposer<TSut> _resultAsserterComposer;
    private readonly ISutAsserterComposer<TSut> _sutAsserterComposer;

    public TestComposer(
        IMockDependencyAsserterComposer<TSut> mockDependencyAsserterComposer,
        IDependencyAsserterComposer<TSut> dependencyAsserterComposer,
        IDependencyBuilderComposer<TSut> dependencyBuilderComposer,
        IMockDependencyBuilderComposer<TSut> mockDependencyBuilderComposer,
        IArrangement arrangement,
        IResultAsserterComposer<TSut> resultAsserterComposer,
        ISutAsserterComposer<TSut> sutAsserterComposer
        )
    {
        _mockDependencyAsserterComposer = mockDependencyAsserterComposer;
        _dependencyAsserterComposer = dependencyAsserterComposer;
        _dependencyBuilderComposer = dependencyBuilderComposer;
        _mockDependencyBuilderComposer = mockDependencyBuilderComposer;
        _resultAsserterComposer = resultAsserterComposer;
        _sutAsserterComposer = sutAsserterComposer;
        Arrangement = arrangement;
    }

    public IValueDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency
        )
    {
        return _dependencyBuilderComposer.Compose(
            dependency,
            newDependency,
            this
        );
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        return _dependencyBuilderComposer.Compose(
            dependency,
            newDependency,
            name,
            this
        );
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        string dependencyName,
        TNewDependency newDependency,
        string newDependencyName
        )
        where TNewDependency : class
    {
        return _dependencyBuilderComposer.Compose(
            dependency,
            dependencyName,
            newDependency,
            newDependencyName,
            this
        );
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> mock,
        TNewDependency newDependency,
        string newDependencyName
        )
        where TDependency : class
    {
        return _dependencyBuilderComposer.Compose(
            mock,
            newDependency,
            newDependencyName,
            this
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency
        )
            where TNewDependency : class
    {
        return _dependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            dependency,
            this
        );
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> mock
        )
        where TDependency : class
    {
        return _dependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            mock,
            this
        );
    }

    public IResultAsserter<TSut, TResult> ComposeMockAsserter<TResult, TDependency>(
        Mock<TDependency> dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
            where TDependency : class
    {
        return _mockDependencyAsserterComposer.Compose(
            dependency,
            func,
            arrangement
        );
    }

    public IVoidAsserter<TSut> ComposeMockAsserter<TDependency>(
        Mock<TDependency> dependency,
        System.Action<TSut> action,
        IArrangement arrangement
        )
        where TDependency : class
    {
        return _mockDependencyAsserterComposer.Compose(
            dependency,
            action,
            arrangement
        );
    }

    public IVoidAsserter<TSut> ComposeMockAsserter<TDependency>(
        Mock<TDependency> dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
            where TDependency : class
    {
        return _mockDependencyAsserterComposer.Compose(
            dependency,
            func,
            arrangement
        );
    }

    public ISutAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        IArrangement arrangement
        )
    {
        return _sutAsserterComposer.Compose(
            dependency,
            arrangement
            );
    }

    public IResultAsserter<TSut, TResult> ComposeAsserter<TResult, TDependency>(
        TDependency dependency,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
    {
        return _dependencyAsserterComposer.Compose(
            dependency,
            func,
            arrangement
        );
    }

    public IVoidAsserter<TSut> ComposeAsserter(
        System.Action<TSut> func,
        IArrangement arrangement
        )
    {
        return _dependencyAsserterComposer.Compose(
            func,
            arrangement
        );
    }

    public IVoidAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
    where TDependency : class
    {
        return _dependencyAsserterComposer.Compose(
            dependency,
            func,
            arrangement
        );
    }

    public IVoidAsserter<TSut> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<TSut> func,
        IArrangement arrangement
        )
    {
        return _dependencyAsserterComposer.Compose(
            dependency,
            func,
            arrangement
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        TDependency currentDependency,
        string currentDependencyName
        )
        where TNewDependency : class
    {
        return _mockDependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            currentDependency,
            currentDependencyName,
            this
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TDependency, TNewDependency>(
        Mock<TDependency> dependencyMock
    )
        where TDependency : class
        where TNewDependency : class
    {
        return _mockDependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            dependencyMock,
            this
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        var mock = new Mock<TNewDependency>();
        
        return new MockDependencyBuilder<TSut, TNewDependency>(
            mock,
            this
            );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedObject<TObject> namedObject
        ) where TNewDependency : class
    {
        //Arrangement.Add(namedObject);

        var dependencyMock = new Mock<TNewDependency>();

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            this
        );

        return builder;
    }

    public IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        INamedObject<TNewDependency> newNamedObject)
    {
        var namedObjectSetter = new NamedObjectSetter<TNewDependency>(
            Arrangement
            );
        
        var builder = new NamedObjectBuilder<TSut, TNewDependency>(
            newNamedObject,
            this,
            _resultAsserterComposer,
            namedObjectSetter
        );

        return builder;
    }
    
    public IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
        )
    {
        var objectSetter = new ObjectSetter<TNewObject>(
            Arrangement
            );

        return new ObjectBuilder<TSut, TNewObject>(
            newObject,
            this,
            _resultAsserterComposer,
            objectSetter
        );
    }

    public IArrangement Arrangement { get; }
    
    public IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        var newMock = new Mock<TNewObject>();

        var mockObjectSetter = new MockObjectSetter<TNewObject>(
            Arrangement
            );
        
        return new MockObjectBuilder<TSut, TNewObject>(
            newMock,
            this,
            mockObjectSetter
            );
    }

    public TNamedObject GetObject<TNamedObject>(string objectName) =>
        Arrangement.GetObject<TNamedObject>(objectName);

    public IObjectBuilder<TSut> StartNewExistingObjectBuilder(
        ITestComposer<TSut> testComposer
        )
    {
        return new ExistingObjectBuilder<TSut>(
            testComposer
        );
    }

    public IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>()
    {
        var dependency = Arrangement.GetThe<TNewDependency>();
        
        Arrangement.AddDependency(dependency);

        return new ExistingObjectBuilder<TSut>(
            this
        );
    }

    public IValueDependencyBuilder<TSut> ComposeValueDependencyBuilder<TObject, TNewDependency>(
        Mock<TObject> mock,
        TNewDependency newDependency
        )
        where TObject : class
    {
        return _dependencyBuilderComposer.Compose(
            mock,
            newDependency,
            this
        );
    }
}
