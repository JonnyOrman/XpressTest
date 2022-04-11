namespace XpressTest;

public interface IMockAsyncResultDependencyBuilder<TSut, TResult>
    :
        IReturnsMockDependencyResultBuilder<TSut, TResult>,
        IReturnsArrangementResultBuilder<TSut, TResult>
{
}