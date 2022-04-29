namespace XpressTest;

public interface IResultPropertyTargeter<TSut, TResult>
:
    IResultValueAsserter<TResult>,
    IArrangementResultValueAsserter<TSut, TResult>
{
    IResultPropertyAsserter<TSut, TResult, TProperty> ThenTheResult<TProperty>(Func<TResult, TProperty> targetFunc);

    void ThenTheResultShouldBeA<TExpectedType>();
}
