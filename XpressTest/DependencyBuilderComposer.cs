using Moq;

namespace XpressTest;

public class DependencyBuilderComposer<TSut> : IDependencyBuilderComposer<TSut>
    where TSut : class
{
    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        TNewDependency newDependency,
        string name,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
    {
        if (currentDependency != null)
        {
            var dependency = new Dependency<TCurrentDependency>(currentDependency, name);

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
        TCurrentDependency currendDependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
    )
        where TNewDependency : class
    {
        if (currendDependency != null)
        {
            var dependency = new Dependency<TCurrentDependency>(currendDependency);

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
