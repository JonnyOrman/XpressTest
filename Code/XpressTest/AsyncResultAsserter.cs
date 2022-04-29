using Xunit;

namespace XpressTest;

public class AsyncResultAsserter<TSut, TResult>
:
    IAsyncResultAsserter<TSut, TResult>
{
    private readonly TResult _result;
    private readonly ISutArrangement<TSut> _arrangement;
    private readonly IResultMockVerifierCreator<TSut, TResult> _resultMockVerifierCreator;

    public AsyncResultAsserter(
        TResult result,
        ISutArrangement<TSut> arrangement,
        IResultMockVerifierCreator<TSut, TResult> resultMockVerifierCreator
        )
    {
        _result = result;
        _arrangement = arrangement;
        _resultMockVerifierCreator = resultMockVerifierCreator;
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBe(Func<ISutArrangement<TSut>, TResult> func)
    {
        var expectedResult = func.Invoke(_arrangement);

        _result.ThenTheResultShouldBe(expectedResult);
    }

    public void ThenTheResultShouldBeNull()
    {
        Assert.Null(_result);
    }

    public IAsyncResultMockVerifier<TSut, TResult, TMock> ThenTheAsync<TMock>() where TMock : class
    {
        return _resultMockVerifierCreator.Create<TMock>(
            this
        );
    }

    public void ThenAsync(Action<IResultAssertion<TResult>> action)
    {
        var assertion = new Assertion<TSut, TResult>(
            _result,
            _arrangement);

        action.Invoke(assertion);
    }

    public IAsyncResultMockVerifier<TSut, TResult, TMock> ThenThe<TMock>() where TMock : class
    {
        var mock = _arrangement.GetTheMock<TMock>();

        return _resultMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public IAsyncResultMockVerifier<TSut, TResult, TMock> ThenAsync<TMock>(
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
}