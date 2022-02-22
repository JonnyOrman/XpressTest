namespace XpressTest;

public static class TestComposerInitialiser<TSut>
    where TSut : class
{
    public static ITestComposer<TSut> Initialise()
    {
        var asserterComposer = new AsserterComposer<TSut>();

        var mockDependencyAsserterComposer = new MockDependencyAsserterComposer<TSut>(
            asserterComposer
            );

        var dependencyAsserterComposer = new DependencyAsserterComposer<TSut>(
            asserterComposer
            );

        var dependencyBuilderComposer = new DependencyBuilderComposer<TSut>();

        var mockDependencyBuilderComposer = new MockDependencyBuilderComposer<TSut>();

        var arrangement = ArrangementInitialiser.Initialise();

        return new TestComposer<TSut>(
            mockDependencyAsserterComposer,
            dependencyAsserterComposer,
            dependencyBuilderComposer,
            mockDependencyBuilderComposer,
            arrangement
        );
    }
}