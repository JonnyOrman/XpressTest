namespace XpressTest;

public class SutAsserterCreator<TSut>
    :
        ISutAsserterCreator<TSut>
{
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly IArrangement _arrangement;

    public SutAsserterCreator(
        ISutComposer<TSut> sutComposer,
        IArrangement arrangement
        )
    {
        _sutComposer = sutComposer;
        _arrangement = arrangement;
    }
    
    public ISutAsserter<TSut> Create()
    {
        var sut = _sutComposer.Compose();
        
        var sutPropertyTargeter = new SutPropertyTargeter<TSut>(
            sut,
            _arrangement
        );
        
        return new SutAsserter<TSut>(
            sutPropertyTargeter
        );
    }
}