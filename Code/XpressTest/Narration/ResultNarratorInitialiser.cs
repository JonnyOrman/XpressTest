namespace XpressTest.Narration;

public static class ResultNarratorInitialiser<TResult>
{
    public static IResultNarrator<TResult> Initialise(
        INarrative narrative
        )
    {
        var expectedResultNarrator = new ExpectedResultNarrator<TResult>();

        var invalidResultNarrator = new InvalidResultNarrator<TResult>();
        
        var resultValueNarrator = new ResultValueNarrator<TResult>(
            expectedResultNarrator,
            invalidResultNarrator
        );

        var passedTestNarrator = new PassedTestNarrator(narrative);
        var failedTestNarrator = new FailedTestNarrator(narrative);
        
        var completionNarrator = new CompletionNarrator(
            passedTestNarrator,
            failedTestNarrator
        );
        
        return new ResultNarrator<TResult>(
            resultValueNarrator,
            completionNarrator
        );
    }
}