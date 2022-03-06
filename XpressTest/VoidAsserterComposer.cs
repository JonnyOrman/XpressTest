namespace XpressTest;

public class VoidAsserterComposer<TSut>
    :
        IVoidAsserterComposer<TSut>
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;

    public VoidAsserterComposer(
        ISutComposer<TSut> sutComposer
        )
    {
        _sutComposer = sutComposer;
    }
    
    public IVoidAsserter<TSut> Compose(
        System.Action<IAction<TSut>> action,
        IArrangement arrangement
        )
    {
        var sut = _sutComposer.Compose(
            arrangement
            );
        
        var sutAction = new Action<TSut>(
            sut,
            arrangement
        );
        
        action.Invoke(sutAction);
        
        var mockCounterVerifierCreatorComposer = new MockCounterVerifierCreatorComposer<IVoidAsserter<TSut>>(
            arrangement
            );
        
        var voidMockVerifierCreator = new VoidMockVerifierCreator<TSut>(
            mockCounterVerifierCreatorComposer
        );
        
        return new VoidAsserter<TSut>(
            arrangement,
            voidMockVerifierCreator,
            sut
        );
    }
}