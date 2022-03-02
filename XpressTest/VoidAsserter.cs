namespace XpressTest;

public class VoidAsserter<TSut> : IVoidAsserter<TSut, System.Action<IArrangement>>
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;

    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut>>> _sutTesterComposer;

    public VoidAsserter(
        ISutComposer<TSut> sutComposer,
        ISutTesterComposer<TSut, System.Action<IAssertion<TSut>>> sutTesterComposer
        )
    {
        _sutComposer = sutComposer;
        _sutTesterComposer = sutTesterComposer;
    }
    
    public ITester Then(System.Action<IArrangement> assertion)
    {
        var sutTester = _sutTesterComposer.Compose(assertion);

        return new Tester<TSut>(
            _sutComposer,
            sutTester
            );
    }

    public IVoidMockVerifier<TSut, System.Action<IArrangement>, TMock> Then<TMock>()
    {
        throw new NotImplementedException();
    }
}