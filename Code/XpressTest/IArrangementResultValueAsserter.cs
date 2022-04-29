namespace XpressTest;

public interface IArrangementResultValueAsserter<TSut, TResult>
{
    void ThenTheResultShouldBe(Func<ISutArrangement<TSut>, TResult> func);
}