namespace XpressTest;

public class SutAsserterComposer<TSut> : ISutAsserterComposer<TSut>
{
    private readonly IArrangementSutComposer<TSut> _sutComposer;

    public SutAsserterComposer(
        IArrangementSutComposer<TSut> sutComposer
        )
    {
        _sutComposer = sutComposer;
    }
    
    public ISutAsserter<TSut> Compose<TDependency>(
        TDependency dependency,
        IArrangement arrangement
        )
    {
        arrangement.AddDependency(dependency);
        
        var sut = _sutComposer.Compose(
            arrangement
            );
        
        var sutPropertyTargeter = new SutPropertyTargeter<TSut>(
            sut,
            arrangement
        );
        
        return new SutAsserter<TSut>(
            sutPropertyTargeter
            );
    }
}