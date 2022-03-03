using Moq;

namespace XpressTest;

public class MockDependencyBuilderComposer<TSut> : IMockDependencyBuilderComposer<TSut>
    where TSut : class
{
    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentMockDependency,
        TNewDependency newDependency,
        string name,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class
        where TNewDependency : class
    {
        if (currentMockDependency != null)
        {
            var dependency = new MockDependency<TCurrentDependency>(currentMockDependency);

            testComposer.Arrangement.Dependencies.Add(dependency);
        }

        var builder = new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            testComposer
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentMockDependency,
        ITestComposer<TSut> testComposer
        )
            where TCurrentDependency : class
            where TNewDependency : class
    {
        if (currentMockDependency != null)
        {
            testComposer.Arrangement.MockObjects.Add(currentMockDependency);
            
            var dependency = new MockDependency<TCurrentDependency>(currentMockDependency);

            testComposer.Arrangement.Dependencies.Add(dependency);
        }

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            new Mock<TNewDependency>(),
            testComposer
        );

        return builder;
    }
}
