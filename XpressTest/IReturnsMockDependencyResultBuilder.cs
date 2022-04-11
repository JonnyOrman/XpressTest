namespace XpressTest;

public interface IReturnsMockDependencyResultBuilder<TSut, TResult>
{
    IDependencyBuilder<TSut> AndReturns(
        TResult expectedResult
    );
}