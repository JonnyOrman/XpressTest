namespace XpressTest;

public class AsserterComposer<TSut> : IAsserterComposer<TSut>
    where TSut : class
{
    public IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        IDependency dependency,
        Func<IAction<TSut>, TResult> func, 
        IArrangement arrangement)
    {
        arrangement.Dependencies.Add(dependency);
        
        var sutComposer = new SutComposer<TSut>(
            arrangement
        );

        var actionExecutor = new ResultActionExecutor<TSut, TResult>(
            func
        );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut, TResult>>(
            actionExecutor,
            arrangement
        );

        var sut = sutComposer.Compose();

        var action = new Action<TSut>(
            sut,
            arrangement
        );

        var result = func.Invoke(action);

        var resultPropertyTargeter = new ResultPropertyTargeter<TResult>(
            result,
            arrangement
            );

        var builder = new ResultAsserter<TSut, TResult>(
            result,
            sutComposer,
            sutTesterComposer,
            resultPropertyTargeter
        );

        return builder;
    }

    public IVoidAsserter<TSut, System.Action<IArrangement>> Compose<TDependency>(
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
