using Moq;

namespace XpressTest;

public interface IMockDependencyBuilderComposer<TSut>
{
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentMockDependency,
        TNewDependency dependency,
        string name,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentDependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
    )
        where TCurrentDependency : class
        where TNewDependency : class;
}
