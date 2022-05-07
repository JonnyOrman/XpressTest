namespace XpressTest.Narration;

public class ResultValueNarrator<TResult>
:
    IResultValueNarrator<TResult>
{
    private readonly IValueNarrator<TResult> _expectedResultNarrator;
    private readonly IValueNarrator<TResult> _invalidResultNarrator;

    public ResultValueNarrator(
        IValueNarrator<TResult> expectedResultNarrator,
        IValueNarrator<TResult> invalidResultNarrator
        )
    {
        _expectedResultNarrator = expectedResultNarrator;
        _invalidResultNarrator = invalidResultNarrator;
    }
    
    public void NarrateExpectedResult(TResult expectedResult)
    {
        _expectedResultNarrator.Narrate(expectedResult);
    }

    public void NarrateValidResult()
    {
        ValidResultNarrator.Narrate();
    }

    public void NarrateInvalidResult(TResult invalidResult)
    {
        _invalidResultNarrator.Narrate(invalidResult);
    }
}