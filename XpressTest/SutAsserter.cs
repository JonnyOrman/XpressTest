namespace XpressTest;

public class SutAsserter<TSut> : ISutPropertyTargeter<TSut>
{
    private readonly ISutPropertyTargeter<TSut> _sutPropertyTargeter;

    public SutAsserter(
        ISutPropertyTargeter<TSut> sutPropertyTargeter
        )
    {
        _sutPropertyTargeter = sutPropertyTargeter;
    }
    
    public ISutPropertyAsserter<TSut, TProperty> ThenIts<TProperty>(
        Func<TSut, TProperty> func
        )
    {
        return _sutPropertyTargeter.ThenIts(func);
    }
}