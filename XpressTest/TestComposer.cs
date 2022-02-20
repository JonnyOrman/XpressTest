using Moq;

namespace XpressTest;

public class TestComposer<TSut> : ITestComposer<TSut>
{
    private readonly IMockDependencyAsserterComposer<TSut> _mockDependencyAsserterComposer;
    private readonly IDependencyAsserterComposer<TSut> _dependencyAsserterComposer;
    private readonly IDependencyBuilderComposer<TSut> _dependencyBuilderComposer;
    private readonly IMockDependencyBuilderComposer<TSut> _mockDependencyBuilderComposer;

    public TestComposer(
        IMockDependencyAsserterComposer<TSut> mockDependencyAsserterComposer,
        IDependencyAsserterComposer<TSut> dependencyAsserterComposer,
        IDependencyBuilderComposer<TSut> dependencyBuilderComposer,
        IMockDependencyBuilderComposer<TSut> mockDependencyBuilderComposer
        )
    {
        _mockDependencyAsserterComposer = mockDependencyAsserterComposer;
        _dependencyAsserterComposer = dependencyAsserterComposer;
        _dependencyBuilderComposer = dependencyBuilderComposer;
        _mockDependencyBuilderComposer = mockDependencyBuilderComposer;
    }

    public IDependencyBuilder<TSut> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        TNewDependency newDependency,
        string name,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
    {
        return _dependencyBuilderComposer.Compose(
            dependency,
            newDependency,
            name,
            arrangement,
            testComposer
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeDependencyBuilder<TDependency, TNewDependency>(
        TDependency dependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
            where TNewDependency : class
    {
        return _dependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            dependency,
            arrangement,
            testComposer
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
        Mock<TDependency> dependencyMock,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
    )
        where TDependency : class
        where TNewDependency : class
    {
        return _mockDependencyBuilderComposer.Compose<TDependency, TNewDependency>(
            dependencyMock,
            arrangement,
            testComposer
        );
    }
}
