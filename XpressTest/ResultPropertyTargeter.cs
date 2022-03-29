using Xunit;

namespace XpressTest;

public class ResultPropertyTargeter<TResult> : IResultPropertyTargeter<TResult>
{
    private readonly TResult _result;
    private readonly IArrangement _arrangement;

    public ResultPropertyTargeter(
        TResult result,
        IArrangement arrangement)
    {
        _result = result;
        _arrangement = arrangement;
    }

    public IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(
        Func<TResult, TProperty> targetFunc
        )
    {
        var resultPropertyValueComparer = new ResultPropertyValueComparer<TResult, TProperty>(
            _result,
            targetFunc
            );
        
        var resultPropertyValueAsserter = new ResultPropertyValueAsserter<TResult, TProperty>(
            resultPropertyValueComparer,
            this
        );

        var resultPropertyNullComparer = new ResultPropertyNullComparer<TResult, TProperty>(
            _result,
            targetFunc
            );
        
        var resultPropertyNullAsserter = new ResultPropertyNullAsserter<TResult>(
            resultPropertyNullComparer,
            this
            );
        
        return new ResultPropertyAsserter<TResult, TProperty>(
            resultPropertyValueAsserter,
            resultPropertyNullAsserter,
            _arrangement
            );
    }
    
    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<IArrangement, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);
        
        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBeA<TExpectedType>()
    {
        _result.ThenTheResultShouldBeA<TExpectedType>();
    }

    public void ThenTheResultShouldNotBeNull()
    {
        Assert.NotNull(_result);
    }
}
