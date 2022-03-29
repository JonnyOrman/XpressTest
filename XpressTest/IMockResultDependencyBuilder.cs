namespace XpressTest;

public interface IMockResultDependencyBuilder<TSut, TDependency, TResult>
{
    IMockDependencyBuilder<TSut, TDependency> AndReturns(
        TResult expectedResult
        );

    IMockDependencyBuilder<TSut, TDependency> AndReturns(
        Func<IArrangement, TResult> expectedResultFunc
        );

    IMockDependencyBuilder<TSut, TDependency> AndReturns<TReturn>()
        where TReturn : class, TResult;
}
