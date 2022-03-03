namespace XpressTest;

public interface IMockResultDependencyBuilder<TSut, TDependency, TResult>
{
    IMockDependencyBuilder<TSut, TDependency> AndReturns(TResult result);

    IMockDependencyBuilder<TSut, TDependency> AndReturns(Func<IArrangement, TResult> resultFunc);

    IMockDependencyBuilder<TSut, TDependency> AndReturns<TReturn>()
        where TReturn : class, TResult;
}
