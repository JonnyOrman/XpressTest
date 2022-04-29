using Xunit;

namespace XpressTest;

public class SutPropertyAsserter<TSut, TProperty>
    :
        ISutPropertyAsserter<TSut, TProperty>
{
    private readonly Func<TSut, TProperty> _targetFunc;
    private readonly ISutArrangement<TSut> _arrangement;

    public SutPropertyAsserter(
        Func<TSut, TProperty> targetFunc,
        ISutArrangement<TSut> arrangement
        )
    {
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

        var actualResult = _targetFunc.Invoke(_arrangement.Sut);

        Assert.Equal(expectedResult, actualResult);

        return new SutPropertyTargeter<TSut>(
            _arrangement
        );
    }

    private ISutPropertyTargeter<TSut> PerformAssertion(Action<TProperty> assertion)
    {
        var actualResult = _targetFunc.Invoke(_arrangement.Sut);

        assertion.Invoke(actualResult);

        return new SutPropertyTargeter<TSut>(
            _arrangement
        );
    }
}