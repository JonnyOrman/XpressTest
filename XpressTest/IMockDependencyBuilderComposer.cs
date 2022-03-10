using Moq;

namespace XpressTest;

public interface IMockDependencyBuilderComposer<TSut>
{
    IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        string currentDependencyName,
        ITestComposer<TSut> testComposer
    )
        where TNewDependency : class;
    
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentMockDependency,
        TNewDependency dependency,
        string name,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentDependency,
        ITestComposer<TSut> testComposer
    )
        where TCurrentDependency : class
        where TNewDependency : class;
}
