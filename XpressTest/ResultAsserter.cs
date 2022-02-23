namespace XpressTest;

public class ResultAsserter<TSut, TResult> : IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult>
    where TSut : class
{
    private readonly ISutComposer<TSut> _sutComposer;

    private readonly ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> _sutTesterComposer;
    private readonly IResultPropertyTargeter<TResult> _resultPropertyTargeter;

    public ResultAsserter(
        ISutComposer<TSut> sutComposer,
        ISutTesterComposer<TSut, System.Action<IAssertion<TSut, TResult>>> sutTesterComposer,
        IResultPropertyTargeter<TResult> resultPropertyTargeter
        )
    {
        _sutComposer = sutComposer;
        _sutTesterComposer = sutTesterComposer;
        _resultPropertyTargeter = resultPropertyTargeter;
    }
    
    public ITester Then(System.Action<IAssertion<TSut, TResult>> assertion)
    {
        var sutTester = _sutTesterComposer.Compose(assertion);

        return new Tester<TSut>(
            _sutComposer,
            sutTester
            );
    }

    public IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc)
    {
        return _resultPropertyTargeter.ThenTheResult(targetFunc);
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _resultPropertyTargeter.ThenTheResultShouldBe(expectedResult);
    }
}