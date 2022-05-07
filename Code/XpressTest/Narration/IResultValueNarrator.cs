namespace XpressTest.Narration;

public interface IResultValueNarrator<TResult>
{
    void NarrateExpectedResult(TResult expectedResult);

    void NarrateValidResult();
    
    void NarrateInvalidResult(TResult invalidResult);
}