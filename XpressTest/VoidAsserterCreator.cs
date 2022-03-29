namespace XpressTest;

public class VoidAsserterCreator<TSut>
    :
        IVoidAsserterCreator<TSut>
where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly IArrangement _arrangement;

    public VoidAsserterCreator(
        ISutComposer<TSut> sutComposer,
        IArrangement arrangement
        )
    {
        _sutComposer = sutComposer;
        _arrangement = arrangement;
    }
    
    public IVoidAsserter<TSut> Create(System.Action<TSut> action)
    {
        var sut = _sutComposer.Compose();
        
        action.Invoke(sut);
        
        var mockCounterVerifierCreatorComposer = new MockCounterVerifierCreatorComposer<IVoidAsserter<TSut>>(
            _arrangement
        );
        
        var voidMockVerifierCreator = new VoidMockVerifierCreator<TSut>(
            mockCounterVerifierCreatorComposer
        );
        
        return new VoidAsserter<TSut>(
            _arrangement,
            voidMockVerifierCreator,
            sut
        );
    }

    public IVoidAsserter<TSut> Create(System.Action<IAction<TSut>> action)
    {
        var sut = _sutComposer.Compose();
        
        var sutAction = new Action<TSut>(
            sut,
            _arrangement
        );
        
        action.Invoke(sutAction);
        
        var mockCounterVerifierCreatorComposer = new MockCounterVerifierCreatorComposer<IVoidAsserter<TSut>>(
            _arrangement
        );
        
        var voidMockVerifierCreator = new VoidMockVerifierCreator<TSut>(
            mockCounterVerifierCreatorComposer
        );
        
        return new VoidAsserter<TSut>(
            _arrangement,
            voidMockVerifierCreator,
            sut
        );
    }
}