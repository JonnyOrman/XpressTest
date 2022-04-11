namespace XpressTest;

public interface IWithAMockBuilder<TSut>
{
    IMockDependencySetupBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
}