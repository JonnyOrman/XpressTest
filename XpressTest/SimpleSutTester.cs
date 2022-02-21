namespace XpressTest;

public class SimpleSutTester<TSut> : ISutTester<TSut>
{
    private readonly ISimpleTestRunner<TSut> _testRunner;

    public SimpleSutTester(
        ISimpleTestRunner<TSut> testRunner
        )
    {
        _testRunner = testRunner;
    }

    public void Test(TSut sut)
    {
        _testRunner.Run(sut);
    }
}
