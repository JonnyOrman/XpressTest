namespace XpressTest;

public class ResultAsserterCreator<TSut>
    :
        IResultAsserterCreator<TSut>
    where TSut : class
{
    private readonly ISutArrangementCreator<TSut> _sutArrangementCreator;

    public ResultAsserterCreator(
        ISutArrangementCreator<TSut> sutArrangementCreator
        )
    {
        _sutArrangementCreator = sutArrangementCreator;
    }

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    )
    {
        var sutArrangement = _sutArrangementCreator.Create();

        var result = func.Invoke(sutArrangement);
        
        Action exceptionAction = () => func.Invoke(sutArrangement);

        return Create(
            sutArrangement,
            result,
            exceptionAction
            );
    }

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<TSut, TResult> func
    )
    {
        var sutArrangement = _sutArrangementCreator.Create();

        var result = func.Invoke(sutArrangement.Sut);

        Action exceptionAction = () => func.Invoke(sutArrangement.Sut);
        
        return Create(
            sutArrangement,
            result,
            exceptionAction
        );
    }

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
    )
    {
        var sutArrangement = _sutArrangementCreator.Create();

        var result = func.Invoke(sutArrangement).Invoke(sutArrangement.Sut);

        Action exceptionAction = () => func.Invoke(sutArrangement).Invoke(sutArrangement.Sut);

        return Create(
            sutArrangement,
            result,
            exceptionAction
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    )
    {
        var sutArrangement = _sutArrangementCreator.Create();
        
        var result = await func.Invoke(
            sutArrangement
        );

        return await CreateAsync(
            sutArrangement,
            result
        );
    }

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(Func<TSut, Task<TResult>> func)
    {
        var sutArrangement = _sutArrangementCreator.Create();

        var result = await func.Invoke(sutArrangement.Sut);

        return await CreateAsync(
            sutArrangement,
            result
        );
    }

    private async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        ISutArrangement<TSut> sutArrangement,
        TResult result
        )
    {
        var mockCounterVerifierCreatorComposer =
            new MockCounterVerifierCreatorComposer<TSut, IResultAsserter<TSut, TResult>>(
                sutArrangement
            );

        var asyncMockCounterVerifierCreatorComposer =
            new AsyncMockCounterVerifierCreatorComposer<TSut, IAsyncResultAsserter<TSut, TResult>>(
                sutArrangement
            );

        var resultMockVerifierCreator = new ResultMockVerifierCreator<TSut, TResult>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
        );

        return new AsyncResultAsserter<TSut, TResult>(
            result,
            sutArrangement,
            resultMockVerifierCreator
        );
    }

    private IResultAsserter<TSut, TResult> Create<TResult>(
        ISutArrangement<TSut> sutArrangement,
        TResult result,
        Action exceptionAction
    )
    {
        var resultPropertyTargeter = new ResultPropertyTargeter<TSut, TResult>(
            result,
            sutArrangement
        );

        var mockCounterVerifierCreatorComposer =
            new MockCounterVerifierCreatorComposer<TSut, IResultAsserter<TSut, TResult>>(
                sutArrangement
            );

        var asyncMockCounterVerifierCreatorComposer =
            new AsyncMockCounterVerifierCreatorComposer<TSut, IAsyncResultAsserter<TSut, TResult>>(
                sutArrangement
            );

        var resultMockVerifierCreator = new ResultMockVerifierCreator<TSut, TResult>(
            mockCounterVerifierCreatorComposer,
            asyncMockCounterVerifierCreatorComposer
        );

        var exceptionAsserter = new ExceptionAsserter(
            exceptionAction
        );

        return new ResultAsserter<TSut, TResult>(
            result,
            sutArrangement,
            resultPropertyTargeter,
            resultMockVerifierCreator,
            exceptionAsserter
        );
    }
}