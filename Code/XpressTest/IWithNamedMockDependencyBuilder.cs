namespace XpressTest;

public interface IWithNamedMockDependencyBuilder<TSut>
{
    IMockDependencySetupBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
        )
        where TNewDependency : class;
}