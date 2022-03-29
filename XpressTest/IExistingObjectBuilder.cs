namespace XpressTest;

public interface IExistingObjectBuilder<TSut>
{
    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
    
    IVoidAsserter<TSut> WhenIt(
        System.Action<TSut> action
    );
    
    IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
    );
    
    IExistingObjectBuilder<TSut> With<T>(string name);
    
    IMockDependencyBuilder<TSut, TMock> WithTheMock<TMock>()
        where TMock : class;
}