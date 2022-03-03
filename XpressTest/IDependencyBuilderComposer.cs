namespace XpressTest;

public interface IDependencyBuilderComposer<TSut>
{
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        TNewDependency dependency,
        string name,
        ITestComposer<TSut> testComposer
        )
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        ITestComposer<TSut> testComposer
        )
            where TNewDependency : class;
}
