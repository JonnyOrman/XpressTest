using Moq;
using Xunit;

namespace XpressTest;

public class AsyncResultAsserter<TSut, TResult>
:
    IAsyncResultAsserter<TSut, TResult>
{
    private readonly TResult _result;
    private readonly IArrangement _arrangement;
    private readonly IResultMockVerifierCreator<TSut, TResult> _resultMockVerifierCreator;
    private readonly TSut _sut;

    public AsyncResultAsserter(
        TResult result,
        IArrangement arrangement,
        IResultMockVerifierCreator<TSut, TResult> resultMockVerifierCreator,
        TSut sut
        )
    {
        _result = result;
        _arrangement = arrangement;
        _resultMockVerifierCreator = resultMockVerifierCreator;
        _sut = sut;
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

    public void ThenTheResultShouldBeNull()
    {
        Assert.Null(_result);
    }

    public IAsyncResultMockVerifier<TSut, TResult, TMock> ThenAsync<TMock>() where TMock : class
    {
        return _resultMockVerifierCreator.Create<TMock>(
            this
        );
    }

    public void ThenAsync(System.Action<IAssertion<TResult>> action)
    {
        var sutAction = new Action<TSut>(_sut, _arrangement);
        
        var assertion = new Assertion<TSut, TResult>(
            _result,
            sutAction);

        action.Invoke(assertion);
    }

    public IAsyncResultMockVerifier<TSut, TResult, TMock> Then<TMock>() where TMock : class
    {
        var mock = _arrangement.GetMock<TMock>();
        
        return _resultMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public IAsyncResultMockVerifier<TSut, TResult, TMock> ThenAsync<TMock>(
        Mock<TMock> mock
        )
        where TMock : class
    {
        return _resultMockVerifierCreator.Create(
            mock,
            this
        );
    }
}