namespace XpressTest;

public interface IResultPropertyAsserter<TResult, TProperty>
{
    IResultPropertyTargeter<TResult> ShouldBe(TProperty expectedValue);
    
    IResultPropertyTargeter<TResult> ShouldBeNull();
}

