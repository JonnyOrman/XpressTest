namespace XpressTest;

public class VoidAsserter<TSut> : IVoidAsserter<TSut>
    where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IVoidMockVerifierCreator<TSut> _voidMockVerifierCreator;
    private readonly TSut _sut;

    public VoidAsserter(
        IArrangement arrangement,
        IVoidMockVerifierCreator<TSut> voidMockVerifierCreator,
        TSut sut
        )
    {
        _arrangement = arrangement;
        _voidMockVerifierCreator = voidMockVerifierCreator;
        _sut = sut;
    }
    
    public IVoidMockVerifier<TSut, TMock> ThenThe<TMock>()
        where TMock : class
    {
        return _voidMockVerifierCreator.Create<TMock>(
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

    public void Then(Action<ISutArrangement<TSut>> action)
    {
        var sutArrangement = new SutArrangement<TSut>(
            _sut,
            _arrangement
            );
        
        var assertion = new VoidAssertion<TSut>(
            sutArrangement
            );

        action.Invoke(assertion);
    }

    public IVoidAsserter<TSut> ThenWhenIt(Action<ISutArrangement<TSut>> action)
    {
        var sutArrangement = new SutArrangement<TSut>(
            _sut,
            _arrangement
        );
        
        action.Invoke(sutArrangement);

        return this;
    }

    public IResultAsserter<TSut, TResult> ThenWhenIt<TResult>(Func<TSut, TResult> func)
    {
        var sutArrangement = new SutArrangement<TSut>(
            _sut,
            _arrangement
        );
        
        var result = func.Invoke(_sut);
        
        var resultPropertyTargeter = new ResultPropertyTargeter<TSut, TResult>(
            result,
            sutArrangement
        );
        
        var mockCounterVerifierCreatorComposer =
            new MockCounterVerifierCreatorComposer<IResultAsserter<TSut, TResult>>(
                _arrangement
            );
        
        var asyncMockCounterVerifierCreatorComposer =
            new AsyncMockCounterVerifierCreatorComposer<IAsyncResultAsserter<TSut, TResult>>(
                _arrangement
            );
        
        var resultMockVerifierCreator = new ResultMockVerifierCreator<TSut, TResult>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
        );
        
        return new ResultAsserter<TSut, TResult>(
            result,
            sutArrangement,
            resultPropertyTargeter,
            resultMockVerifierCreator
        );
    }
}