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
    ) =>
        CreateResultAsserter(sut => func.Invoke(new Action<TSut>(
            sut,
            _arrangement
        )));

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<TSut, TResult> func
    ) =>
        CreateResultAsserter(sut => func.Invoke(sut));

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IArrangement, Func<TSut, TResult>> func
    ) =>
        CreateResultAsserter(sut => func.Invoke(_arrangement).Invoke(sut));

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<IAction<TSut>, Task<TResult>> func
    ) =>
        await CreateAsyncResultAsserter(async sut => await func.Invoke(new Action<TSut>(
            sut,
            _arrangement
        )));

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(Func<TSut, Task<TResult>> func) =>
        await CreateAsyncResultAsserter(async sut => await func.Invoke(sut));

    private IResultAsserter<TSut, TResult> CreateResultAsserter<TResult>(
        Func<TSut, TResult> resultFunc
    )
    {
        var sut = _sutComposer.Compose();

        var result = resultFunc.Invoke(sut);

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

    private async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(
        Func<TSut, Task<TResult>> resultFunc
    )
    {
        var sut = _sutComposer.Compose();

        var result = await resultFunc.Invoke(sut);

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