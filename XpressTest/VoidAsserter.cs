namespace XpressTest;

public class VoidAsserter<TSut>
    :
        IVoidAsserter<TSut>
    where TSut : class
{
    private readonly ISutArrangement<TSut> _sutArrangement;
    private readonly IVoidMockVerifierCreator<TSut> _voidMockVerifierCreator;
    private readonly IExceptionAsserter _exceptionAsserter;

    public VoidAsserter(
        ISutArrangement<TSut> sutArrangement,
        IVoidMockVerifierCreator<TSut> voidMockVerifierCreator,
        IExceptionAsserter exceptionAsserter
        )
    {
        _sutArrangement = sutArrangement;
        _voidMockVerifierCreator = voidMockVerifierCreator;
        _exceptionAsserter = exceptionAsserter;
    }
    
    public IVoidMockVerifier<TSut, TMock> ThenThe<TMock>()
        where TMock : class
    {
        return _voidMockVerifierCreator.Create<TMock>(
            this
            );
    }

    public IVoidMockVerifier<TSut, TMock> ThenThe<TMock>(
        string name
        )
        where TMock : class
    {
        var mock = _sutArrangement.GetTheMock<TMock>(name);
        
        return _voidMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public IVoidMockVerifier<TSut, TMock> Then<TMock>(
        Moq.Mock<TMock> moqMock
        )
        where TMock : class
    {
        var mock = new Mock<TMock>(moqMock);
        
        return _voidMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public void Then(
        Action<ISutArrangement<TSut>> action
        )
    {
        var assertion = new VoidAssertion<TSut>(
            _sutArrangement
            );

        action.Invoke(assertion);
    }

    public IVoidAsserter<TSut> ThenWhenIt(Action<ISutArrangement<TSut>> action)
    {
        action.Invoke(_sutArrangement);

        return this;
    }

    public IResultAsserter<TSut, TResult> ThenWhenIt<TResult>(
        Func<TSut, TResult> func
        )
    {
        var result = func.Invoke(_sutArrangement.Sut);
        
        var resultPropertyTargeter = new ResultPropertyTargeter<TSut, TResult>(
            result,
            _sutArrangement
        );
        
        var mockCounterVerifierCreatorComposer =
            new MockCountVerifierCreatorComposer<TSut, IResultAsserter<TSut, TResult>>(
                _sutArrangement
            );
        
        var asyncMockCounterVerifierCreatorComposer =
            new AsyncMockCounterVerifierCreatorComposer<TSut, IAsyncResultAsserter<TSut, TResult>>(
                _sutArrangement
            );
        
        var resultMockVerifierCreator = new ResultMockVerifierCreator<TSut, TResult>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
        );
        
        return new ResultAsserter<TSut, TResult>(
            result,
            _sutArrangement,
            resultPropertyTargeter,
            resultMockVerifierCreator,
            _exceptionAsserter
        );
    }

    public void ThenItShouldThrow<TException>()
        where TException : Exception
    {
        _exceptionAsserter.ThenItShouldThrow<TException>();
    }
}