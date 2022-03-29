namespace XpressTest;

public interface IDependencyBuilder<TSut>
    :
        IConstructedSutAsserter<TSut>
{
    IExistingObjectBuilder<TSut> With<TNewDependency>()
        where TNewDependency : class;
    
    IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
        );
    
    IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
    
    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(string name)
        where TNewDependency : class;
    
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
    );
    
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<TSut, TResult> func
    );

    IVoidAsserter<TSut> WhenIt(
        System.Action<TSut> action
    );
    
    IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
    );
    
    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func   
    );
    
    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
    );
}