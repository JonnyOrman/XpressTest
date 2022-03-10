namespace XpressTest;

public class SutPropertyTargeter<TSut> : ISutPropertyTargeter<TSut>
{
    private readonly TSut _sut;
    private readonly IArrangement _arrangement;

    public SutPropertyTargeter(
        TSut sut
        )
    {
        _sut = sut;
    }
    
    public SutPropertyTargeter(
        TSut sut,
        IArrangement arrangement
        ) : this(sut)
    {
        _arrangement = arrangement;
    }
    
    public ISutPropertyAsserter<TSut, TProperty> ThenIts<TProperty>(Func<TSut, TProperty> func)
    {
        return new SutPropertyAsserter<TSut, TProperty>(
            _sut,
            func,
            _arrangement
        );
    }
}