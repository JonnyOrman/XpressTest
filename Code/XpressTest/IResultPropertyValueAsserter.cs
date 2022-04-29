namespace XpressTest;

public interface IResultPropertyValueAsserter<TSut, TResult, TProperty>
{
    IResultPropertyTargeter<TSut, TResult> Assert(TProperty expectedValue);
}