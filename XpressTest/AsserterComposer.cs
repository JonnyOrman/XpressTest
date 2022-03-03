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
            resultPropertyTargeter
        );

        return builder;
    }

    public IVoidAsserter<TSut> Compose<TDependency>(
        IDependency dependency,
        System.Action<IAction<TSut>> action,
        IArrangement arrangement
        )
    where TDependency : class
    {
        if (dependency is MockDependency<TDependency> mockDependency)
        {
            arrangement.MockObjects.Add(mockDependency.Mock);
        }
        
        arrangement.Dependencies.Add(dependency);

        var sutComposer = new SutComposer<TSut>(
            arrangement
        );

        var sut = sutComposer.Compose();
        
        var sutAction = new Action<TSut>(
            sut,
            arrangement
        );
        
        action.Invoke(sutAction);

        var builder = new VoidAsserter<TSut>(
            sutComposer
        );

        return builder;
    }
}
