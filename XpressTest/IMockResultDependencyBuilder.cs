namespace XpressTest;

public interface IMockResultDependencyBuilder<TSut, TResult>
:
    IReturnsMockDependencyResultBuilder<TSut, TResult>,
    IReturnsArrangementResultBuilder<TSut, TResult>,
    IReturnsMockBuilder<TResult, IDependencyBuilder<TSut>>
{
}
