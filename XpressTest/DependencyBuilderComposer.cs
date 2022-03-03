using Moq;

namespace XpressTest;

public class DependencyBuilderComposer<TSut> : IDependencyBuilderComposer<TSut>
    where TSut : class
{
    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        TNewDependency newDependency,
        string name,
        ITestComposer<TSut> testComposer
        )
    where TNewDependency : class
    {
        if (currentDependency != null)
        {
            var dependency = new Dependency<TCurrentDependency>(currentDependency, name);

            testComposer.Arrangement.Dependencies.Add(dependency);
        }

        var builder = new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            testComposer
        );

        return builder;
    }

    public IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currendDependency,
        ITestComposer<TSut> testComposer
    )
        where TNewDependency : class
    {
        if (currendDependency != null)
        {
            var dependency = new Dependency<TCurrentDependency>(currendDependency);

            testComposer.Arrangement.Dependencies.Add(dependency);
        }

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            new Mock<TNewDependency>(),
            testComposer
        );

        return builder;
    }
}
