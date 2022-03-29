using Moq;

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
    
    public IVoidMockVerifier<TSut, TMock> Then<TMock>()
        where TMock : class
    {
        return _voidMockVerifierCreator.Create<TMock>(
            this
            );
    }

    public IVoidMockVerifier<TSut, TMock> Then<TMock>(
        Mock<TMock> mock
        )
        where TMock : class
    {
        return _voidMockVerifierCreator.Create(
            mock,
            this
        );
    }

    public void Then(System.Action<IAssertion> action)
    {
        var sutAction = new Action<TSut>(_sut, _arrangement);
        
        var assertion = new VoidAssertion<TSut>(
            sutAction
            );

        action.Invoke(assertion);
    }

    public IVoidAsserter<TSut> ThenWhenIt(System.Action<IAction<TSut>> action)
    {
        var sutAction = new Action<TSut>(_sut, _arrangement);
        
        action.Invoke(sutAction);

        return this;
    }

    public IResultAsserter<TSut, TResult> ThenWhenIt<TResult>(Func<TSut, TResult> func)
    {
        var action = new Action<TSut>(
            _sut,
            _arrangement
        );
        
        var result = func.Invoke(_sut);
        
        var resultPropertyTargeter = new ResultPropertyTargeter<TResult>(
            result,
            _arrangement
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
            _arrangement,
            resultPropertyTargeter,
            resultMockVerifierCreator,
            _sut
        );
    }
}