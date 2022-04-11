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
    
    public IVoidAsserter<TSut> Create(Action<TSut> action)
    {
        return CreateVoidAsserter(sut => action.Invoke(sut));
    }

    public IVoidAsserter<TSut> Create(Action<ISutArrangement<TSut>> action)
    {
        return CreateVoidAsserter(sut => action.Invoke(new SutArrangement<TSut>(
            sut,
            _arrangement
        )));
    }
    
    private IVoidAsserter<TSut> CreateVoidAsserter(
        Action<TSut> sutAction
    )
    {
        var sut = _sutComposer.Compose();

        var sutArrangement = new SutArrangement<TSut>(
            sut,
            _arrangement
        );

        sutAction.Invoke(sut);

        var mockCounterVerifierCreatorComposer = new MockCounterVerifierCreatorComposer<IVoidAsserter<TSut>>(
            _arrangement
        );
        
        var voidMockVerifierCreator = new VoidMockVerifierCreator<TSut>(
            mockCounterVerifierCreatorComposer
        );
        
        return new VoidAsserter<TSut>(
            sutArrangement,
            voidMockVerifierCreator,
            sut
        );
    }
}