namespace XpressTest;

public class AsserterComposer<TSut> : IAsserterComposer<TSut>
    where TSut : class
{
    public IAsserter<System.Action<IAssertion<TSut, TResult>>> Compose<TResult, TDependency>(
        IDependency dependency,
        Func<IAction<TSut>, TResult> action, 
        IArrangement arrangement)
    {
        arrangement.Dependencies.Add(dependency);

        var sutComposer = new SutComposer<TSut>(
            arrangement
        );

        var actionExecutor = new ResultActionExecutor<TSut, TResult>(
            action
            );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut, TResult>>(
            actionExecutor,
            arrangement
        );

        var builder = new ResultAsserter<TSut, TResult>(
            sutComposer,
            sutTesterComposer
        );

        return builder;
    }

    public IAsserter<System.Action<IArrangement>> Compose<TDependency>(
        IDependency dependency,
        System.Action<IAction<TSut>> action,
        IArrangement arrangement
        )
    {
        arrangement.Dependencies.Add(dependency);

        var sutComposer = new SutComposer<TSut>(
            arrangement
        );

        var actionExecutor = new VoidActionExecutor<TSut>(
            action
            );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut>>(
            actionExecutor,
            arrangement
        );

        var builder = new VoidAsserter<TSut>(
            sutComposer,
            sutTesterComposer
        );

        return builder;
    }
}
