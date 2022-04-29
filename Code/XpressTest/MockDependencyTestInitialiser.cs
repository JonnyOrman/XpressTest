namespace XpressTest;

public static class MockDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IMockDependencySetupBuilder<TSut, TDependency> Initialise<TDependency>()
    where TDependency : class
    {
        var moqMock = new Moq.Mock<TDependency>();

        var dependencyMock = new Mock<TDependency>(
            moqMock
            );

        var container = ContainerComposer<TSut>.Compose();

        return container.MockDependencyBuilderCreator.Create(dependencyMock);
    }
}
