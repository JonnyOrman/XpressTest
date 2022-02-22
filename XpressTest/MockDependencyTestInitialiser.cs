using Moq;

namespace XpressTest;

public static class MockDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IMockDependencyBuilder<TSut, TDependency> Initialise<TDependency>()
    where TDependency : class
    {
        var dependencyMock = new Mock<TDependency>();
        
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new MockDependencyBuilder<TSut, TDependency>(
            dependencyMock,
            testComposer
        );
    }
}
