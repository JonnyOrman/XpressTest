namespace XpressTest;

public class TestRunner<TSut, TAssertion> : ITestRunner<TSut>
    where TAssertion : IAssertion<TSut>
{
    private readonly IActionExecutor<TSut, TAssertion> _actionExecutor;
    private readonly System.Action<TAssertion> _assertion;

    public TestRunner(
        IActionExecutor<TSut, TAssertion> actionExecutor,
        System.Action<TAssertion> assertion
        )
    {
        _actionExecutor = actionExecutor;
        _assertion = assertion;
    }

    public void Run(IAction<TSut> action)
    {
        var assertion = _actionExecutor.Execute(action);

        _assertion.Invoke(assertion);
    }
}
