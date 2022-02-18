namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IAsserter<System.Action<IAssertion<TSut, TResult>>>
    where TSut : class
{
    private readonly Func<IAction<TSut>, TResult> _action;
    private readonly IDependencyCollection _dependencies;
    private readonly IObjectCollection _objects;

    public ResultAsserter(
        Func<IAction<TSut>, TResult> action,
        IDependencyCollection dependencies,
        IObjectCollection objects
        )
    {
        _action = action;
        _dependencies = dependencies;
        _objects = objects;
    }
    
    public ITester ThenItShould(System.Action<IAssertion<TSut, TResult>> assertion)
    {
        return new ResultTester<TSut, TResult>(
            _action,
            assertion,
            _dependencies,
            _objects
            );
    }
}