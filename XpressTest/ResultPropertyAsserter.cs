using Xunit;

namespace XpressTest;

public class ResultPropertyAsserter<TResult, TProperty> : IResultPropertyAsserter<TResult, TProperty>
{
    private readonly TResult _result;
    private readonly Func<TResult, TProperty> _targetFunc;

    public ResultPropertyAsserter(
        TResult result,
        Func<TResult, TProperty> targetFunc
        )
    {
        _result = result;
        _targetFunc = targetFunc;
    }

    public IResultPropertyTargeter<TResult> ShouldBe(TProperty expectedValue)
    {
        var actualResult = _targetFunc.Invoke(_result);

        Assert.Equal(expectedValue, actualResult);

        return new ResultPropertyTargeter<TResult>(_result);
    }
}
