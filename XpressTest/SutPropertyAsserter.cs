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

    public ISutPropertyTargeter<TSut> ShouldBeNull() =>
        PerformAssertion(actualResult => Assert.Null(actualResult));

    public ISutPropertyTargeter<TSut> ShouldBe(TProperty value) =>
        PerformAssertion(actualResult => Assert.Equal(value, actualResult));

    private ISutPropertyTargeter<TSut> PerformAssertion(System.Action<TProperty> assertion)
    {
        var actualResult = _targetFunc.Invoke(_sut);

        assertion.Invoke(actualResult);

        return new SutPropertyTargeter<TSut>(
            _sut,
            _arrangement
        );
    }
}