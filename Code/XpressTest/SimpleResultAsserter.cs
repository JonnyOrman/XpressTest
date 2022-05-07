using XpressTest.Narration;

namespace XpressTest;

public class SimpleResultAsserter<TSut, TResult>
    :
        ISimpleResultAsserter<TResult>
{
    private readonly TSut _sut;
    private readonly IArrangement _arrangement;
    private readonly Func<TResult> _func;
    private readonly IExceptionAsserter _exceptionAsserter;
    private readonly IResultNarrator<TResult> _resultNarrator;

    public SimpleResultAsserter(
        TSut sut,
        IArrangement arrangement,
        Func<TResult> func,
        IExceptionAsserter exceptionAsserter,
        IResultNarrator<TResult> resultNarrator
        )
    {
        _sut = sut;
        _arrangement = arrangement;
        _func = func;
        _exceptionAsserter = exceptionAsserter;
        _resultNarrator = resultNarrator;
    }

    public void Then(Action<IResultAssertion<TResult>> action)
    {
        var result = _func.Invoke();

        var sutAction = new SutArrangement<TSut>(_sut, _arrangement);

        var assertion = new Assertion<TSut, TResult>(
            result,
            sutAction);

        action.Invoke(assertion);
    }

    public void ThenTheResultShouldBe(TResult expectedResult)
    {
        _resultNarrator.NarrateExpectedResult(expectedResult);

        var result = _func.Invoke();

        try
        {
            result.ThenTheResultShouldBe(expectedResult);
        }
        catch (Exception exception)
        {
            _resultNarrator.NarrateInvalidResult(result);
            
            _resultNarrator.NarrateFailedTest();
            
            throw;
        }

        _resultNarrator.NarrateValidResult();
        
        _resultNarrator.NarratePassedTest();
    }

    public void ThenItShouldThrow<TException>()
        where TException : Exception
    {
        _exceptionAsserter.ThenItShouldThrow<TException>();
    }
}