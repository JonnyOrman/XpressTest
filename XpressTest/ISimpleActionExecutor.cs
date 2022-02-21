namespace XpressTest;

public interface ISimpleActionExecutor<TSut, TResult>
{
    TResult Execute(TSut sut);
}
