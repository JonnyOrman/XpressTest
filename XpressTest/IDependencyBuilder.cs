namespace XpressTest;

public interface IDependencyBuilder<TSut>
    :
        IConstructedSutAsserter<TSut>
{
    IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
        );
    
    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
    
    IVoidAsserter<TSut> WhenIt(
        System.Action<TSut> action
    );
}