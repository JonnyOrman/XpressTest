using Moq;

namespace XpressTest;

public static class MockDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IMockDependencyBuilder<TSut, TDependency> Initialise<TDependency>()
    where TDependency : class
    {
        var dependencyMock = new Mock<TDependency>();

        var arrangement = ArrangementInitialiser.Initialise();

        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        var builder = new MockDependencyBuilder<TSut, TDependency>(
            dependencyMock,
            arrangement,
            testComposer
        );

        return builder;
    }
}
