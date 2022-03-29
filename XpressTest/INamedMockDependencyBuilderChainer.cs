namespace XpressTest;

public interface INamedMockDependencyBuilderChainer<TSut>
{
    IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<IAction<TSut>, TResult> func
        );

    IMockDependencyBuilder<TSut, TDependency> StartNamedMockDependencyBuilder<TDependency>(
        string name
        )
        where TDependency : class;
}