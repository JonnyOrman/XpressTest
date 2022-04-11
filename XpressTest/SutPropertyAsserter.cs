using Xunit;

namespace XpressTest;

public class SutPropertyAsserter<TSut, TProperty>
    :
        ISutPropertyAsserter<TSut, TProperty>
{
    private readonly TSut _sut;
    private readonly Func<TSut, TProperty> _targetFunc;
    private readonly ISutArrangement<TSut> _arrangement;

    public SutPropertyAsserter(
        TSut sut,
        Func<TSut, TProperty> targetFunc,
        ISutArrangement<TSut> arrangement
        )
    {
        _sut = sut;
        _targetFunc = targetFunc;
        _arrangement = arrangement;
    }

    public ISutPropertyTargeter<TSut> ShouldBeNull() =>
        PerformAssertion(actualResult => Assert.Null(actualResult));

    public ISutPropertyTargeter<TSut> ShouldBe(TProperty value) =>
        PerformAssertion(actualResult => Assert.Equal(value, actualResult));

    public ISutPropertyTargeter<TSut> ShouldBe(Func<ISutArrangement<TSut>, TProperty> func)
    {
        var expectedResult = func.Invoke(_arrangement);
        
        var actualResult = _targetFunc.Invoke(_sut);

        Assert.Equal(expectedResult, actualResult);

        return new SutPropertyTargeter<TSut>(
            _sut,
            _arrangement
        );
    }

    private ISutPropertyTargeter<TSut> PerformAssertion(Action<TProperty> assertion)
    {
        var actualResult = _targetFunc.Invoke(_sut);

        assertion.Invoke(actualResult);

        return new SutPropertyTargeter<TSut>(
            _sut,
            _arrangement
        );
    }
}