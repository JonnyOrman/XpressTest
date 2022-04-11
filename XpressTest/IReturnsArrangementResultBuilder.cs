namespace XpressTest;

public interface IReturnsArrangementResultBuilder<TSut, TResult>
{
    IDependencyBuilder<TSut> AndReturns(
        Func<IReadArrangement, TResult> expectedResultFunc
    );
}