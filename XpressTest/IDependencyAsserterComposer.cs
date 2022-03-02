namespace XpressTest;

public interface IDependencyAsserterComposer<TSut>
{
    IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        TDependency dependencyValue,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement);

    IVoidAsserter<TSut, System.Action<IArrangement>> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement);
}
