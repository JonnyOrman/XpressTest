using Xunit;

namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IResultAsserter<TSut, TResult>
    where TSut : class
{
    private readonly TResult _result;
    private readonly ISutArrangement<TSut> _sutArrangement;
    private readonly IResultPropertyTargeter<TSut, TResult> _resultPropertyTargeter;
    private readonly IResultMockVerifierCreator<TSut, TResult> _resultMockVerifierCreator;

    public ResultAsserter(
        TResult result,
        ISutArrangement<TSut> sutArrangement,
        IResultPropertyTargeter<TSut, TResult> resultPropertyTargeter,
        IResultMockVerifierCreator<TSut, TResult> resultMockVerifierCreator
        )
    {
        _result = result;
        _sutArrangement = sutArrangement;
        _resultPropertyTargeter = resultPropertyTargeter;
        _resultMockVerifierCreator = resultMockVerifierCreator;
    }
    
    public void Then(
        Action<IResultAssertion<TResult>> action
        )
    {
        var assertion = new Assertion<TSut, TResult>(
            _result,
            _sutArrangement);

        action.Invoke(assertion);
    }

    public IResultMockVerifier<TSut, TResult, TMock> ThenThe<TMock>()
        where TMock : class
    {
        var mock = _sutArrangement.GetTheMock<TMock>();
        
        return _resultMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public IResultMockVerifier<TSut, TResult, TMock> ThenThe<TMock>(string name)
        where TMock : class
    {
        var mock = _sutArrangement.GetTheMock<TMock>(name);
        
        return _resultMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public IResultMockVerifier<TSut, TResult, TMock> Then<TMock>(
        Moq.Mock<TMock> moqMock
        )
        where TMock : class
    {
        var mock = new Mock<TMock>(moqMock);
        
        return _resultMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public void ThenTheResultShouldBeNull()
    {
        Assert.Null(_result);
    }

    public IResultPropertyAsserter<TSut, TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc)
    {
        return _resultPropertyTargeter.ThenTheResult(targetFunc);
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _resultPropertyTargeter.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<ISutArrangement<TSut>, TResult> func)
    {
        var expectedResult = func.Invoke(_sutArrangement);
        
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