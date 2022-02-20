namespace XpressTest;

public class DependencyAsserterComposer<TSut> : IDependencyAsserterComposer<TSut>
{
    private readonly IAsserterComposer<TSut> _asserterComposer;

    public DependencyAsserterComposer(
        IAsserterComposer<TSut> asserterComposer
        )
    {
        _asserterComposer = asserterComposer;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> Compose<TResult, TDependency>(
        TDependency dependencyValue,
        Func<IAction<TSut>, TResult> func,
        IArrangement arrangement
        )
    {
        var dependency = new Dependency<TDependency>(dependencyValue);

        return _asserterComposer.Compose<TResult, TDependency>(
            dependency,
            func,
            arrangement
            );
    }

    public IAsserter<System.Action<IArrangement>> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
    {
        var dependency = new Dependency<TDependency>(dependencyValue);

        return _asserterComposer.Compose<TDependency>(
            dependency,
            func,
            arrangement
            );
    }
}
