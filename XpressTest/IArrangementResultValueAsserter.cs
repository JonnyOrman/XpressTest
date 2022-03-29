namespace XpressTest;

public interface IArrangementResultValueAsserter<TResult>
{
    void ThenTheResultShouldBe(Func<IArrangement, TResult> func);
}