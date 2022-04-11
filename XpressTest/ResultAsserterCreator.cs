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
        Func<ISutArrangement<TSut>, TResult> func
    ) =>
        CreateResultAsserter(sut => func.Invoke(new SutArrangement<TSut>(
            sut,
            _arrangement
        )));

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<TSut, TResult> func
    ) =>
        CreateResultAsserter(sut => func.Invoke(sut));

    public IResultAsserter<TSut, TResult> Create<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
    ) =>
        CreateResultAsserter(sut => func.Invoke(_arrangement).Invoke(sut));

    public async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsync<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    ) =>
        await CreateAsyncResultAsserter(async sut => await func.Invoke(new SutArrangement<TSut>(
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

        var sutArrangement = new SutArrangement<TSut>(
            sut,
            _arrangement
        );

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

    private async Task<IAsyncResultAsserter<TSut, TResult>> CreateAsyncResultAsserter<TResult>(
        Func<TSut, Task<TResult>> resultFunc
    )
    {
        var sut = _sutComposer.Compose();

        var result = await resultFunc.Invoke(sut);

        var sutArrangement = new SutArrangement<TSut>(
            sut,
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

        return new AsyncResultAsserter<TSut, TResult>(
            result,
            sutArrangement,
            resultMockVerifierCreator
        );
    }
}