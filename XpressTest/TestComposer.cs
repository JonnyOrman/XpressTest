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

    public TestComposer(
        IMockDependencyAsserterComposer<TSut> mockDependencyAsserterComposer,
        IDependencyAsserterComposer<TSut> dependencyAsserterComposer,
        IDependencyBuilderComposer<TSut> dependencyBuilderComposer,
        IMockDependencyBuilderComposer<TSut> mockDependencyBuilderComposer,
        IArrangement arrangement,
        IResultAsserterComposer<TSut> resultAsserterComposer
        )
    {
        _mockDependencyAsserterComposer = mockDependencyAsserterComposer;
        _dependencyAsserterComposer = dependencyAsserterComposer;
        _dependencyBuilderComposer = dependencyBuilderComposer;
        _mockDependencyBuilderComposer = mockDependencyBuilderComposer;
        _resultAsserterComposer = resultAsserterComposer;
        Arrangement = arrangement;
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

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency
        )
            where TNewDependency : class
    {
        return _dependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            dependency,
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

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedMock<TObject> mock
        )
            where TNewDependency : class
            where TObject : class
    {
        var mockObject = new NamedMock<TObject>(
            mock.Mock,
            mock.Name
        );

        Arrangement.Add(mockObject);

        var newMock = new Mock<TNewDependency>();
        
        return new MockDependencyBuilder<TSut, TNewDependency>(
            newMock,
            this
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(Mock<TObject> mock)
        where TNewDependency : class
        where TObject : class
    {
        Arrangement.Add(mock);
        
        var dependencyMock = new Mock<TNewDependency>();

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            this
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedObject<TObject> namedObject
        ) where TNewDependency : class
    {
        Arrangement.Add(namedObject);

        var dependencyMock = new Mock<TNewDependency>();

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            this
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(TObject obj) where TNewDependency : class
    {
        Arrangement.Add(obj);

        var dependencyMock = new Mock<TNewDependency>();

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            this
        );

        return builder;
    }

    public IObjectBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency, TObject>(INamedObject<TObject> oldNamedObject,
        INamedObject<TNewDependency> newNamedObject)
    {
        Arrangement.Add(oldNamedObject);

        var builder = new NamedObjectBuilder<TSut, TNewDependency>(
            newNamedObject,
            this,
            _resultAsserterComposer
        );

        return builder;
    }
    
    public IObjectBuilder<TSut> StartNewObjectBuilder<TOldObject, TNewObject>(TOldObject oldObject, TNewObject newObject)
    {
        Arrangement.Add(oldObject);

        var builder = new ObjectBuilder<TSut, TNewObject>(
            newObject,
            this,
            _resultAsserterComposer
        );

        return builder;
    }

    public IArrangement Arrangement { get; }
    
    public IMockObjectBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject, TObject>(Mock<TObject> mock)
        where TNewObject : class
        where TObject : class
    {
        Arrangement.Add(mock);
        
        var newMock = new Mock<TNewObject>();
        
        return new MockObjectBuilder<TSut, TNewObject>(
            newMock,
            this
            );
    }
}
