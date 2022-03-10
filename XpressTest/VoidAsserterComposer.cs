namespace XpressTest;

public class VoidAsserterComposer<TSut>
    :
        IVoidAsserterComposer<TSut>
    where TSut : class
{
    private readonly IArrangementSutComposer<TSut> _sutComposer;

    public VoidAsserterComposer(
        IArrangementSutComposer<TSut> sutComposer
        )
    {
        _sutComposer = sutComposer;
    }

    public IVoidAsserter<TSut> Compose(System.Action<TSut> action, IArrangement arrangement)
    {
        var sut = _sutComposer.Compose(
            arrangement
        );
        
        action.Invoke(sut);
        
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