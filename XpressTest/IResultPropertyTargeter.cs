namespace XpressTest;

public interface IResultPropertyTargeter<TResult>
:
    IResultValueAsserter<TResult>,
    IArrangementResultValueAsserter<TResult>
{
    IResultPropertyAsserter<TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc);
    
    void ThenTheResultShouldBeA<TExpectedType>();
}
