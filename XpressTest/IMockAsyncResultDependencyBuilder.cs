namespace XpressTest;

public interface IMockAsyncResultDependencyBuilder<TSut, TDependency, TResult>
{
    IMockDependencyBuilder<TSut, TDependency> AndReturns(
        TResult expectedResult
    );

    IMockDependencyBuilder<TSut, TDependency> AndReturns(
        Func<IArrangement, TResult> resultFunc
    );
}