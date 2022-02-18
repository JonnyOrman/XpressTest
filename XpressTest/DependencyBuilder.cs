using Moq;

namespace XpressTest;

public class DependencyBuilder<TSut, TDependency> :
    IDependencyBuilder<TSut>
    where TSut : class
{
    private readonly TDependency _dependency;
    
    private readonly IDependencyCollection _dependencies;
    
    private readonly IObjectCollection _objects;

    public DependencyBuilder(
        TDependency dependency,
        IDependencyCollection dependencies,
        IObjectCollection objects
        )
    {
        _dependency = dependency;
        _dependencies = dependencies;
        _objects = objects;
    }
    
    
    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        var dependency = new Dependency<TDependency>(_dependency, name);
        
        _dependencies.Add(dependency);
        
        var builder = new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            _dependencies,
            _objects
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
            _dependencies,
            _objects
            );
        
        return builder;
    }
    
    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        var dependency = new Dependency<TDependency>(_dependency);
        
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
        var dependency = new Dependency<TDependency>(_dependency);
        
        _dependencies.Add(dependency);
        
        var builder = new VoidAsserter<TSut>(
            func,
            _dependencies,
            _objects
        );

        return builder;
    }
}