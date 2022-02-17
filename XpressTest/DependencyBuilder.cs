using Moq;

namespace XpressTest;

public class DependencyBuilder<TSut, TDependency> :
    IDependencyBuilder<TSut>
    where TSut : class
{
    private readonly TDependency _dependency;
    
    private readonly ICollection<IDependency> _dependencies;
    
    public DependencyBuilder(
        TDependency dependency,
        ICollection<IDependency> dependencies
        )
    {
        _dependency = dependency;
        _dependencies = dependencies;
    }
    
    
    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        var dependency = new Dependency<TDependency>(_dependency);
        
        _dependencies.Add(dependency);
        
        var builder = new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            _dependencies
        );
        
        return builder;
    }
    
    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        var dependency = new Dependency<TDependency>(_dependency);
        
        _dependencies.Add(dependency);

        var newMock = new Mock<TNewDependency>();
        
        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            newMock,
            _dependencies
            );
        
        return builder;
    }
    
    public IAsserter<Action<TResult>> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        var dependency = new Dependency<TDependency>(_dependency);
        
        _dependencies.Add(dependency);
        
        var builder = new ResultAsserter<TSut, TResult>(
            func,
            _dependencies
        );

        return builder;
    }

    public IAsserter<Action> WhenIt(Action<TSut> func)
    {
        var dependency = new Dependency<TDependency>(_dependency);
        
        _dependencies.Add(dependency);
        
        var builder = new VoidAsserter<TSut>(
            func,
            _dependencies
        );

        return builder;
    }
}