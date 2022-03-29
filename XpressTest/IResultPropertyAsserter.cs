namespace XpressTest;

public interface IResultPropertyAsserter<TResult, TProperty>
{
    IResultPropertyTargeter<TResult> ShouldBe(TProperty expectedValue);
    
    IResultPropertyTargeter<TResult> ShouldBe(Func<IArrangement, TProperty> expectedValueFunc);
    
    IResultPropertyTargeter<TResult> ShouldBeNull();
}