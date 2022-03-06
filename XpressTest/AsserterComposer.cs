namespace XpressTest;

public class AsserterComposer<TSut>
    :
        IAsserterComposer<TSut>
    where TSut : class
{
    private readonly IResultAsserterComposer<TSut> _resultAsserterComposer;
    private readonly IVoidAsserterComposer<TSut> _voidAsserterComposer;

    public AsserterComposer(
        IResultAsserterComposer<TSut> resultAsserterComposer,
        IVoidAsserterComposer<TSut> voidAsserterComposer
        )
    {
        _resultAsserterComposer = resultAsserterComposer;
        _voidAsserterComposer = voidAsserterComposer;
    }
    
    public IResultAsserter<TSut, TResult> Compose<TResult, TDependency>(
        IDependency dependency,
        Func<IAction<TSut>, TResult> func, 
        IArrangement arrangement)
    {
        arrangement.Dependencies.Add(dependency);
        
        return _resultAsserterComposer.Compose(
            func,
            arrangement
            );
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

        return _voidAsserterComposer.Compose(
            action,
            arrangement
        );
    }
}
