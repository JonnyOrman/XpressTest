namespace XpressTest;

public class SutPropertyTargeter<TSut> : ISutPropertyTargeter<TSut>
{
    private readonly ISutArrangement<TSut> _arrangement;

    public SutPropertyTargeter(
        ISutArrangement<TSut> arrangement
        )
    {
        _arrangement = arrangement;
    }

    public ISutPropertyAsserter<TSut, TProperty> ThenIts<TProperty>(
        Func<TSut, TProperty> func
        )
    {
        return new SutPropertyAsserter<TSut, TProperty>(
            func,
            _arrangement
        );
    }
}