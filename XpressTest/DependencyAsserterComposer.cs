namespace XpressTest;

public class DependencyAsserterComposer<TSut>
    :
        IDependencyAsserterComposer<TSut>
{
    private readonly IAsserterComposer<TSut> _asserterComposer;

    public DependencyAsserterComposer(
        IAsserterComposer<TSut> asserterComposer
        )
    {
        _asserterComposer = asserterComposer;
    }

    public IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
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

    public IVoidAsserter<TSut> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<IAction<TSut>> func,
        IArrangement arrangement
        )
    where TDependency : class
    {
        var dependency = new Dependency<TDependency>(dependencyValue);

        return _asserterComposer.Compose<TDependency>(
            dependency,
            func,
            arrangement
            );
    }

    public IVoidAsserter<TSut> Compose<TDependency>(
        TDependency dependencyValue,
        System.Action<TSut> action,
        IArrangement arrangement
        )
    {
        var dependency = new Dependency<TDependency>(dependencyValue);

        return _asserterComposer.ComposeValue<TDependency>(
            dependency,
            action,
            arrangement
        );
    }

    public IVoidAsserter<TSut> Compose(
        System.Action<TSut> action,
        IArrangement arrangement
        )
    {
        return _asserterComposer.Compose(
            action,
            arrangement
        );
    }
}
