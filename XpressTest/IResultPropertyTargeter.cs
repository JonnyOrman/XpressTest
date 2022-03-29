namespace XpressTest;

public interface IResultPropertyTargeter<TResult>
{
    IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc);
    
    void ThenTheResultShouldBe(TResult expectedResult);

    void ThenTheResultShouldBe(Func<IArrangement, TResult> func);

    void ThenTheResultShouldBeA<TExpectedType>();

    void ThenTheResultShouldNotBeNull();
}
