namespace XpressTest;

public class ResultAsserterCreator<TSut>
:
    IResultAsserterCreator<TSut>
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;
    private readonly IArrangement _arrangement;

    public ResultAsserterCreator(
        ISutComposer<TSut> sutComposer,
        IArrangement arrangement
        )
    {
        _sutComposer = sutComposer;
        _arrangement = arrangement;
    }
    
    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IAction<TSut>, TResult> func
        )
    {
        var sut = _sutComposer.Compose();
        
        var action = new Action<TSut>(
            sut,
            _arrangement
        );
        
        var result = func.Invoke(action);
        
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
            sut
        );
    }

    public IResultAsserter<TSut, TResult> Create<TResult>(Func<TSut, TResult> func)
    {
        var sut = _sutComposer.Compose();
        
        var result = func.Invoke(sut);
        
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
            sut
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
        )
    {
        var sut = _sutComposer.Compose();
        
        var action = new Action<TSut>(
            sut,
            _arrangement
        );
        
        var result = await func.Invoke(action);
        
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
        
        return new AsyncResultAsserter<TSut, TResult>(
            result,
            _arrangement,
            resultMockVerifierCreator,
            sut
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        var sut = _sutComposer.Compose();
        
        var result = await func.Invoke(sut);
        
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
        
        return new AsyncResultAsserter<TSut, TResult>(
            result,
            _arrangement,
            resultMockVerifierCreator,
            sut
        );
    }
}