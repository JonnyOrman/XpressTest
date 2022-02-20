namespace XpressTest;

public class VoidAssertion<TSut> : IAssertion<TSut>
{
    public VoidAssertion(
        IAction<TSut> action
        )
    {
        Action = action;
    }

    public IObjectCollection Objects => Action.Objects;

    public IDependencyCollection Dependencies => Action.Dependencies;

    public IAction<TSut> Action { get; }
}
