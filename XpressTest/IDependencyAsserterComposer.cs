namespace XpressTest;

public interface IDependencyAsserterComposer<TSut>
{
    IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> Compose<TResult, TDependency>(
        TDependency dependencyValue,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement);

    IAsserter<System.Action<IArrangement>> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement);
}
