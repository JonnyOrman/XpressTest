namespace XpressTest;

public interface IResultPropertyNullAsserter<TResult>
{
    IResultPropertyTargeter<TResult> Assert();
}