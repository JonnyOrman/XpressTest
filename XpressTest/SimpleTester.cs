namespace XpressTest;

public class SimpleTester<TSut> : ITester
{
    private readonly ISutTester<TSut> _sutTester;

    public SimpleTester(
        ISutTester<TSut> sutTester
        )
    {
        _sutTester = sutTester;
    }

    public void Test()
    {
        var sut = Activator.CreateInstance<TSut>();

        _sutTester.Test(sut);
    }
}
