namespace XpressTest;

public interface IMoqMockDependencyBuilderCreator<TSut>
where TSut : class
{
    IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>(
        IMock<TDependency> moqMock
        )
        where TDependency : class;
}