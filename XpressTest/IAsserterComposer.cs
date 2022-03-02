namespace XpressTest;

public interface IAsserterComposer<TSut>
{
    IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        IDependency dependency,
        Func<IAction<TSut>, TResult> action,
        IArrangement arrangement
        );

    IVoidAsserter<TSut, System.Action<IArrangement>> Compose<TDependency>(
        IDependency dependency,
        System.Action<IAction<TSut>> action,
        IArrangement arrangement
        );
}
