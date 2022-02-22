﻿using Moq;

namespace XpressTest;

public class TestComposer<TSut> : ITestComposer<TSut>
    where TSut : class
{
    private readonly IMockDependencyAsserterComposer<TSut> _mockDependencyAsserterComposer;
    private readonly IDependencyAsserterComposer<TSut> _dependencyAsserterComposer;
    private readonly IDependencyBuilderComposer<TSut> _dependencyBuilderComposer;
    private readonly IMockDependencyBuilderComposer<TSut> _mockDependencyBuilderComposer;
    private readonly IArrangement _arrangement;

    public TestComposer(
        IMockDependencyAsserterComposer<TSut> mockDependencyAsserterComposer,
        IDependencyAsserterComposer<TSut> dependencyAsserterComposer,
        IDependencyBuilderComposer<TSut> dependencyBuilderComposer,
        IMockDependencyBuilderComposer<TSut> mockDependencyBuilderComposer,
        IArrangement arrangement
        )
    {
        _mockDependencyAsserterComposer = mockDependencyAsserterComposer;
        _dependencyAsserterComposer = dependencyAsserterComposer;
        _dependencyBuilderComposer = dependencyBuilderComposer;
        _mockDependencyBuilderComposer = mockDependencyBuilderComposer;
        _arrangement = arrangement;
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name
        )
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

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> ComposeMockAsserter<TResult, TDependency>(
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

    public IAsserter<System.Action<IArrangement>> ComposeMockAsserter<TDependency>(
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

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> ComposeAsserter<TResult, TDependency>(
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

    public IAsserter<System.Action<IArrangement>> ComposeAsserter<TDependency>(
        TDependency dependency,
        System.Action<IAction<TSut>> func,
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

        _arrangement.Add(mockObject);

        var newMock = new Mock<TNewDependency>();
        
        return new MockDependencyBuilder<TSut, TNewDependency>(
            newMock,
            this
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> StartNewMockDependencyBuilder<TNewDependency, TObject>(
        INamedObject<TObject> namedObject
        ) where TNewDependency : class
    {
        _arrangement.Add(namedObject);

        var dependencyMock = new Mock<TNewDependency>();

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            this
        );

        return builder;
    }

    public IObjectBuilder<TSut> StartNewObjectBuilder<TNewObject, TObject>(
        INamedObject<TObject> oldNamedObject,
        INamedObject<TNewObject> newNamedObject
        )
    {
        _arrangement.Add(oldNamedObject);

        var builder = new ObjectBuilder<TSut, TNewObject>(
            newNamedObject,
            this
        );

        return builder;
    }

    public IArrangement Arrangement => _arrangement;
}
