namespace XpressTest;

public interface IResultPropertyAsserter<TSut, TResult, TProperty>
{
    IResultPropertyTargeter<TSut, TResult> ShouldBe(TProperty expectedValue);

    IResultPropertyTargeter<TSut, TResult> ShouldBe(Func<IReadArrangement, TProperty> expectedValueFunc);

    IResultPropertyTargeter<TSut, TResult> ShouldBeNull();
}