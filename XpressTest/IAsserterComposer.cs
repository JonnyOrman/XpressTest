namespace XpressTest;

public interface IAsserterComposer<TSut>
{
    IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> Compose<TResult, TDependency>(
        IDependency dependency,
        Func<IAction<TSut>, TResult> action,
        IArrangement arrangement
        );

    IAsserter<System.Action<IArrangement>> Compose<TDependency>(
        IDependency dependency,
        System.Action<IAction<TSut>> action,
        IArrangement arrangement
        );
}
