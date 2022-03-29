namespace XpressTest;

public interface IAsyncResultPropertyTargeter<TResult>
{
    void ThenTheResultShouldBe(TResult expectedResult);
    
    void ThenTheResultShouldBe(Func<IArrangement, TResult> func);
    
    void ThenTheResultShouldBeNull();
}