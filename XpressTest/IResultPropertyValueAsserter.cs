namespace XpressTest;

public interface IResultPropertyValueAsserter<TResult, TProperty>
{
    IResultPropertyTargeter<TResult> Assert(TProperty expectedValue);
}