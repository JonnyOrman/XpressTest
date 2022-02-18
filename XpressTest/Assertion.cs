namespace XpressTest;

public class Assertion<TSut, TResult> : IAssertion<TSut, TResult>
{
    public Assertion(
        TResult result,
        IAction<TSut> action
        )
    {
        Result = result;
        Action = action;
    }
    
    public TResult Result { get; }
    
    public IAction<TSut> Action { get; }

    public IObjectCollection Objects => Action.Objects;

    public IDependencyCollection Dependencies => Action.Dependencies;
}