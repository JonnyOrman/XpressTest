namespace XpressTest;

public interface INamedMockDependencyBuilderChainer<TSut>
{
    IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<IAction<TSut>, TResult> func
        );

    INamedMockDependencyBuilder<TSut, TDependency> StartNamedMockDependencyBuilder<TDependency>(
        string name
        )
        where TDependency : class;
}