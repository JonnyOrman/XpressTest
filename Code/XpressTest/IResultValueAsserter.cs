namespace XpressTest;

public interface IResultValueAsserter<TResult>
{
    void ThenTheResultShouldBe(TResult expectedResult);
}