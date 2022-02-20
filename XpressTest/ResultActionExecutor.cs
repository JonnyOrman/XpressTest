namespace XpressTest;

public class ResultActionExecutor<TSut, TResult>
    :
        ActionExecutor<Func<IAction<TSut>, TResult>>,
        IActionExecutor<TSut, IAssertion<TSut, TResult>>
{
    public ResultActionExecutor(
        Func<IAction<TSut>, TResult> action
        ) : base(action)
    {
    }

    public IAssertion<TSut, TResult> Execute(IAction<TSut> action)
    {
        var actualResult = _action.Invoke(action);

        var assertion = new Assertion<TSut, TResult>(
            actualResult,
            action
        );

        return assertion;
    }
}
