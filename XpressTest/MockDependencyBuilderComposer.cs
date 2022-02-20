using Moq;

namespace XpressTest;

public class MockDependencyBuilderComposer<TSut> : IMockDependencyBuilderComposer<TSut>
    where TSut : class
{
    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentMockDependency,
        TNewDependency newDependency,
        string name,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class
    {
        if (currentMockDependency != null)
        {
            var dependency = new MockDependency<TCurrentDependency>(currentMockDependency);

            arrangement.Dependencies.Add(dependency);
        }

        var builder = new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            arrangement,
            testComposer
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentMockDependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
            where TCurrentDependency : class
            where TNewDependency : class
    {
        if (currentMockDependency != null)
        {
            var dependency = new MockDependency<TCurrentDependency>(currentMockDependency);

            arrangement.Dependencies.Add(dependency);
        }

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            new Mock<TNewDependency>(),
            arrangement,
            testComposer
        );

        return builder;
    }
}
