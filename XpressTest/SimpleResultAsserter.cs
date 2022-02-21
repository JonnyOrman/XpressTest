namespace XpressTest;

public class SimpleResultAsserter<TSut, TResult> : ISimpleAsserter<TResult>
{
    private readonly ISutTesterComposer<TSut, TResult> _sutTesterComposer;

    public SimpleResultAsserter(
        ISutTesterComposer<TSut, TResult> sutTesterComposer
        )
    {
        _sutTesterComposer = sutTesterComposer;
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        var sutTester = _sutTesterComposer.Compose(expectedResult);

        var tester = new SimpleTester<TSut>(
            sutTester
        );

        tester.Test();
    }
}
