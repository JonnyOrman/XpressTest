namespace XpressTest;

public interface IAsserterComposer<TSut>
{
    IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        IDependency dependency,
        Func<IAction<TSut>, TResult> action,
        IArrangement arrangement
        );

    IVoidAsserter<TSut> Compose<TDependency>(
        IDependency dependency,
        System.Action<IAction<TSut>> action,
        IArrangement arrangement
        )
        where TDependency : class;
}
