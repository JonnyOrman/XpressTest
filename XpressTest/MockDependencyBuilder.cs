using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockDependencyBuilder<TSut, TDependency> :
    IMockDependencyBuilder<TSut, TDependency>
    where TSut : class
    where TDependency : class
{
    private readonly Mock<TDependency> _dependencyMock;
    
    private readonly ICollection<IDependency> _dependencies;

    public MockDependencyBuilder(
        Mock<TDependency> dependencyMock,
        ICollection<IDependency> dependencies
        )
    {
        _dependencyMock = dependencyMock;
        _dependencies = dependencies;
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        if (_dependencyMock != null)
        {
            var dependency = new MockDependency<TDependency>(_dependencyMock);
            
            _dependencies.Add(dependency);
        }

        var builder = new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            _dependencies
            );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        if (_dependencyMock != null)
        {
            var dependency = new MockDependency<TDependency>(_dependencyMock);
            
            _dependencies.Add(dependency);
        }

        var newMock = new Mock<TNewDependency>();

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            newMock,
            _dependencies
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TDependency> That<TDependencyResult>(Expression<Func<TDependency, TDependencyResult>> func, TDependencyResult dependencyResult)
    {
         _dependencyMock.Setup(func).Returns(dependencyResult);
         
         return this;
    }

    public IAsserter<Action<TResult>> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        var dependency = new MockDependency<TDependency>(_dependencyMock);
        
        _dependencies.Add(dependency);
        
        var builder = new ResultAsserter<TSut, TResult>(
            func,
            _dependencies
        );

        return builder;
    }

    public IAsserter<Action> WhenIt(Action<TSut> func)
    {
        var dependency = new MockDependency<TDependency>(_dependencyMock);
        
        _dependencies.Add(dependency);
        
        var builder = new VoidAsserter<TSut>(
            func,
            _dependencies
        );

        return builder;
    }
}