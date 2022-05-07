namespace XpressTest.Narration;

public class CompletionNarrator
:
    ICompletionNarrator
{
    private readonly INarrator _passedTestNarrator;
    private readonly INarrator _failedTestNarrator;

    public CompletionNarrator(
        INarrator passedTestNarrator,
        INarrator failedTestNarrator
        )
    {
        _passedTestNarrator = passedTestNarrator;
        _failedTestNarrator = failedTestNarrator;
    }
    
    public void NarratePassedTest()
    {
        _passedTestNarrator.Narrate();
    }

    public void NarrateFailedTest()
    {
        _failedTestNarrator.Narrate();
    }
}