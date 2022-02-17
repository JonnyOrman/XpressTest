namespace XpressTest;

public class VoidAsserter<TSut> : IAsserter<Action>
    where TSut : class
{
    private readonly Action<TSut> _action;
    private readonly ICollection<IDependency> _dependencies;

    public VoidAsserter(
        Action<TSut> action,
        ICollection<IDependency> dependencies
        )
    {
        _action = action;
        _dependencies = dependencies;
    }
    
    public ITester ThenItShould(Action assertion)
    {
        return new VoidTester<TSut>(
            _action,
            assertion,
            _dependencies
            );
    }
}