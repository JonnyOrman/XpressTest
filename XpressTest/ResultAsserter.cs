namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IAsserter<System.Action<IAssertion<TSut, TResult>>>
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;

    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> _sutTesterComposer;

    public ResultAsserter(
        ISutComposer<TSut> sutComposer,
        ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> sutTesterComposer
        )
    {
        _sutComposer = sutComposer;
        _sutTesterComposer = sutTesterComposer;
    }
    
    public ITester ThenItShould(System.Action<IAssertion<TSut, TResult>> assertion)
    {
        var sutTester = _sutTesterComposer.Compose(assertion);

        return new Tester<TSut>(
            _sutComposer,
            sutTester
            );
    }
}