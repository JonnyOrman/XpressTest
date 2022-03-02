using Xunit;

namespace XpressTest;

public class ResultPropertyAsserter<TResult, TProperty> : IResultPropertyAsserter<TResult, TProperty>
{
    private readonly TResult _result;
    private readonly Func<TResult, TProperty> _targetFunc;
    private readonly IArrangement _arrangement;

    public ResultPropertyAsserter(
        TResult result,
        Func<TResult, TProperty> targetFunc,
        IArrangement arrangement
        )
    {
        _result = result;
        _targetFunc = targetFunc;
        _arrangement = arrangement;
    }

    public IResultPropertyTargeter<TResult> ShouldBe(TProperty expectedValue)
    {
        var actualResult = _targetFunc.Invoke(_result);

        Assert.Equal(expectedValue, actualResult);

        return new ResultPropertyTargeter<TResult>(
            _result,
            _arrangement
            );
    }
}
