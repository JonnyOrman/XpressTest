namespace XpressTest;

public interface INamedMockResultDependencyBuilder<TSut, TDependency, TResult>
{
    INamedMockDependencyBuilder<TSut, TDependency> AndReturns(
        Func<IArrangement, TResult> expectedResultFunc
        );
}