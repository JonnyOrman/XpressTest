namespace XpressTest;

public class SimpleSutTesterComposer<TSut, TResult> : ISutTesterComposer<TSut, TResult>
{
    private readonly ISimpleActionExecutor<TSut, TResult> _actionExecutor;

    public SimpleSutTesterComposer(
        ISimpleActionExecutor<TSut, TResult> actionExecutor
        )
    {
        _actionExecutor = actionExecutor;
    }

    public ISutTester<TSut> Compose(TResult expectedResult)
    {
        var testRunner = new SimpleTestRunner<TSut, TResult>(
            _actionExecutor,
            expectedResult
        );

        return new SimpleSutTester<TSut>(
            testRunner
        );
    }
}
