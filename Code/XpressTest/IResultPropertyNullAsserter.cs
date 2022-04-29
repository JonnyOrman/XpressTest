namespace XpressTest;

public interface IResultPropertyNullAsserter<TSut, TResult>
{
    IResultPropertyTargeter<TSut, TResult> Assert();
}