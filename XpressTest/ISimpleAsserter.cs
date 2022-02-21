namespace XpressTest;

public interface ISimpleAsserter<TResult>
{
    void ThenTheResultShouldBe(TResult expectedResult);
}
