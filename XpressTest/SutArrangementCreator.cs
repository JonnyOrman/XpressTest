namespace XpressTest;

public class SutArrangementCreator<TSut>
:
    ISutArrangementCreator<TSut>
{
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly IArrangement _arrangement;

    public SutArrangementCreator(
        ISutComposer<TSut> sutComposer,
        IArrangement arrangement
        )
    {
        _sutComposer = sutComposer;
        _arrangement = arrangement;
    }
    
    public ISutArrangement<TSut> Create()
    {
        var sut = _sutComposer.Compose();
        
        return new SutArrangement<TSut>(
            sut,
            _arrangement
        );
    }
}