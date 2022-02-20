namespace XpressTest;

public class Tester<TSut> : ITester
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;
    
    private readonly ISutTester<TSut> _sutTester;

    public Tester(
        ISutComposer<TSut> sutComposer,
        ISutTester<TSut> sutTester
        )
    {
        _sutComposer = sutComposer;
        _sutTester = sutTester;
    }

    public void Test()
    {
        var sut = _sutComposer.Compose();
        
        _sutTester.Test(sut);
    }
}