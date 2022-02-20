namespace XpressTest;

public class SutTester<TSut> : ISutTester<TSut>
{
    private readonly IArrangement _arrangement;
    private readonly ITestRunner<TSut> _testRunner;

    public SutTester(
        IArrangement arrangement,
        ITestRunner<TSut> testRunner
        )
    {
        _arrangement = arrangement;
        _testRunner = testRunner;
    }

    public void Test(TSut sut)
    {
        var action = new Action<TSut>(
            sut,
            _arrangement
        );

        _testRunner.Run(action);
    }
}
