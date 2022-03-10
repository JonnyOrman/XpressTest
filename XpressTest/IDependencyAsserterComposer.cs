namespace XpressTest;

public interface IDependencyAsserterComposer<TSut>
{
    IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        TDependency dependencyValue,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        );

    IVoidAsserter<TSut> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
        where TDependency : class;
    
    IVoidAsserter<TSut> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<TSut> action,
        IArrangement arrangement
        );
    
    IVoidAsserter<TSut> Compose(
        System.Action<TSut> action,
        IArrangement arrangement
    );
}
