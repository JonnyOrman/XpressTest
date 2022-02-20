namespace XpressTest;

public class SutTesterComposer<TSut, TAssertion> : ISutTesterComposer<TSut, System.Action<TAssertion>>
    where TAssertion : IAssertion<TSut>
{
    private readonly IActionExecutor<TSut, TAssertion> _actionExecutor;
    private readonly IArrangement _arrangement;

    public SutTesterComposer(
        IActionExecutor<TSut, TAssertion> actionExecutor,
        IArrangement arrangement
        )
    {
        _actionExecutor = actionExecutor;
        _arrangement = arrangement;
    }

    public ISutTester<TSut> Compose(System.Action<TAssertion> assertion)
    {
        var testRunner = new TestRunner<TSut, TAssertion>(
            _actionExecutor,
            assertion
        );

        return new SutTester<TSut>(
            _arrangement,
            testRunner
        );
    }
}
