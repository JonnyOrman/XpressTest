using Xunit;

namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IResultAsserter<TSut, TResult>
    where TSut : class
{
    private readonly TResult _result;
    private readonly IArrangement _arrangement;
    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;
    private readonly IResultMockVerifierCreator<TSut, TResult> _resultMockVerifierCreator;
    private readonly TSut _sut;

    public ResultAsserter(
        TResult result,
        IArrangement arrangement,
        IResultPropertyTargeter<TResult> resultPropertyTargeter,
        IResultMockVerifierCreator<TSut, TResult> resultMockVerifierCreator,
        TSut sut
        )
    {
        _result = result;
        _arrangement = arrangement;
        _resultPropertyTargeter = resultPropertyTargeter;
        _resultMockVerifierCreator = resultMockVerifierCreator;
        _sut = sut;
    }
    
    public void Then(System.Action<IAssertion<TResult>> action)
    {
        var sutAction = new Action<TSut>(_sut, _arrangement);
        
        var assertion = new Assertion<TSut, TResult>(
            _result,
            sutAction);

        action.Invoke(assertion);
    }

    public IResultMockVerifier<TSut, TResult, TMock> Then<TMock>()
        where TMock : class
    {
        return _resultMockVerifierCreator.Create<TMock>(
            this
            );
    }

    public void ThenTheResultShouldBeNull()
    {
        Assert.Null(_result);
    }

    public IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc)
    {
        return _resultPropertyTargeter.ThenTheResult(targetFunc);
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _resultPropertyTargeter.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<IArrangement, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);
        
        _result.ThenTheResultShouldBe(expectedResult);
    }
}