namespace XpressTest.Narration;

public interface IResultNarrator<TResult>
{
    void NarrateExpectedResult(TResult expectedResult);

    void NarrateValidResult();
    
    void NarrateInvalidResult(TResult actualResult);

    void NarratePassedTest();

    void NarrateFailedTest();
}