namespace XpressTest;

public interface IMockAsyncResultDependencyBuilder<TSut, TResult>
    :
        IReturnsMockResultBuilder<TResult, IDependencyBuilder<TSut>>,
        IReturnsArrangementResultBuilder<TResult, IDependencyBuilder<TSut>>
{
}