namespace XpressTest;

public class SutAsserterCreator<TSut>
    :
        ISutAsserterCreator<TSut>
{
    private readonly ISutArrangementCreator<TSut> _sutArrangementCreator;

    public SutAsserterCreator(
        ISutArrangementCreator<TSut> sutArrangementCreator
        )
    {
        _sutArrangementCreator = sutArrangementCreator;
    }
    
    public ISutPropertyTargeter<TSut> Create()
    {
        var sutArrangement = _sutArrangementCreator.Create();
        
        var sutPropertyTargeter = new SutPropertyTargeter<TSut>(
            sutArrangement
        );
        
        return new SutAsserter<TSut>(
            sutPropertyTargeter
        );
    }
}