namespace XpressTest.Narration;

public class ResultNarrator<TResult>
:
    IResultNarrator<TResult>
{
    private readonly IResultValueNarrator<TResult> _resultValueNarrator;
    private readonly ICompletionNarrator _completionNarrator;

    public ResultNarrator(
        IResultValueNarrator<TResult> resultValueNarrator,
        ICompletionNarrator completionNarrator
        )
    {
        _resultValueNarrator = resultValueNarrator;
        _completionNarrator = completionNarrator;
    }
    
    public void NarrateExpectedResult(TResult expectedResult)
    {
        _resultValueNarrator.NarrateExpectedResult(expectedResult);
    }

    public void NarrateValidResult()
    {
        _resultValueNarrator.NarrateValidResult();
    }

    public void NarrateInvalidResult(TResult actualResult)
    {
        _resultValueNarrator.NarrateInvalidResult(actualResult);
    }

    public void NarratePassedTest()
    {
        _completionNarrator.NarratePassedTest();
    }

    public void NarrateFailedTest()
    {
        _completionNarrator.NarrateFailedTest();
    }
}