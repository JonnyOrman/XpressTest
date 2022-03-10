using Xunit;

namespace XpressTest;

public class SutPropertyAsserter<TSut, TProperty>
    :
        ISutPropertyAsserter<TSut, TProperty>
{
    private readonly TSut _sut;
    private readonly Func<TSut, TProperty> _targetFunc;
    private readonly IArrangement _arrangement;

    public SutPropertyAsserter(
        TSut sut,
        Func<TSut, TProperty> targetFunc,
        IArrangement arrangement
        )
    {
        _sut = sut;
        _targetFunc = targetFunc;
        _arrangement = arrangement;
    }

    public ISutPropertyTargeter<TSut> ShouldBeNull()
    {
        var actualResult = _targetFunc.Invoke(_sut);

        Assert.Null(actualResult);

        return new SutPropertyTargeter<TSut>(
            _sut,
            _arrangement
        );
    }

    public ISutPropertyTargeter<TSut> ShouldBe(TProperty value)
    {
        var actualResult = _targetFunc.Invoke(_sut);

        Assert.Equal(value, actualResult);

        return new SutPropertyTargeter<TSut>(
            _sut,
            _arrangement
        );
    }
}