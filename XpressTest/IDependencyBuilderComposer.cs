namespace XpressTest;

public interface IDependencyBuilderComposer<TSut>
{
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currendDependency,
        TNewDependency dependency,
        string name,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        );

    IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
            where TNewDependency : class;
}
