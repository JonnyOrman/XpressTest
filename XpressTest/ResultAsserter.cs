namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IAsserter<Action<TResult>>
    where TSut : class
{
    private readonly Func<TSut, TResult> _action;
    private readonly ICollection<IDependency> _dependencies;

    public ResultAsserter(
        Func<TSut, TResult> action,
        ICollection<IDependency> dependencies
        )
    {
        _action = action;
        _dependencies = dependencies;
    }
    
    public ITester ThenItShould(Action<TResult> assertion)
    {
        return new ResultTester<TSut, TResult>(
            _action,
            assertion,
            _dependencies
            );
    }
}