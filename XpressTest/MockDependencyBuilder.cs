using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockDependencyBuilder<TSut, TDependency> :
    IMockDependencyBuilder<TSut, TDependency>
    where TSut : class
    where TDependency : class
{
    private readonly Mock<TDependency> _dependencyMock;
    
    private readonly IDependencyCollection _dependencies;
    private readonly IObjectCollection _objects;

    public MockDependencyBuilder(
        Mock<TDependency> dependencyMock,
        IDependencyCollection dependencies,
        IObjectCollection objects
        )
    {
        _dependencyMock = dependencyMock;
        _dependencies = dependencies;
        _objects = objects;
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
            _dependencies,
            _objects
            );

        return builder;
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        throw new NotImplementedException();
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
            _dependencies,
            _objects
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TDependency> That<TDependencyResult>(
        Func<IArrangement, MockSetup<TDependency, TDependencyResult>> func
        )
    {
        var arrangement = new Arrangement(
            _objects,
            _dependencies
        );
        
        var result = func.Invoke(arrangement);

         _dependencyMock.Setup(result.When).Returns(result.Then);
         
         return this;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        var dependency = new MockDependency<TDependency>(_dependencyMock);
        
        _dependencies.Add(dependency);
        
        var builder = new ResultAsserter<TSut, TResult>(
            func,
            _dependencies,
            _objects
        );

        return builder;
    }

    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        var dependency = new MockDependency<TDependency>(_dependencyMock);
        
        _dependencies.Add(dependency);
        
        var builder = new VoidAsserter<TSut>(
            func,
            _dependencies,
            _objects
        );

        return builder;
    }
}