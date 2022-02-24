using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockDependencyBuilder<TSut, TDependency> :
    IMockDependencyBuilder<TSut, TDependency>
    where TSut : class
    where TDependency : class
{
    private readonly Mock<TDependency> _dependencyMock;
    
    private readonly ITestComposer<TSut> _testComposer;

    public MockDependencyBuilder(
        Mock<TDependency> dependencyMock,
        ITestComposer<TSut> testComposer
        )
    {
        _dependencyMock = dependencyMock;
        _testComposer = testComposer;
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependencyMock,
            newDependency,
            null
        );
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.ComposeMockDependencyBuilder<TDependency, TNewDependency>(
            _dependencyMock
        );
    }
    
    public IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            func,
            _testComposer.Arrangement
            );
    }
    
    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            func,
            _testComposer.Arrangement
        );
    }
    
    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(Func<IArrangement, Expression<Func<TDependency, TResult>>> func)
    {
        var expression = func.Invoke(_testComposer.Arrangement);

        return new MockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _dependencyMock,
            this,
            _testComposer.Arrangement
            );
    }
}