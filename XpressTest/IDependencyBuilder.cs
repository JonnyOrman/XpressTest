namespace XpressTest;

public interface IDependencyBuilder<TSut>
    :
        IActor<TSut>,
        IConstructedSutAsserter<TSut>
{
    IDependencyBuilder<TSut> With<TNewDependency>();
    
    IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency);
    
    IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
        where TNewDependency : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
}