namespace XpressTest;

public class VoidActionExecutor<TSut>
    :
        ActionExecutor<System.Action<IAction<TSut>>>,
        IActionExecutor<TSut, IAssertion<TSut>>
{
    public VoidActionExecutor(
        System.Action<IAction<TSut>> action
        ) : base(action)
    {
    }

    public IAssertion<TSut> Execute(IAction<TSut> action)
    {
        _action.Invoke(action);

        var assertion = new VoidAssertion<TSut>(
            action
        );

        return assertion;
    }
}
