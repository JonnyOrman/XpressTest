namespace XpressTest;

public interface IDependencyBuilder<TSut> : IActor<TSut>
{
    IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name);
    
    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
}