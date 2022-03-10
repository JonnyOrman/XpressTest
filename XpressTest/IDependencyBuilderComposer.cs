using Moq;

namespace XpressTest;

public interface IDependencyBuilderComposer<TSut>
{
    IValueDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        TNewDependency dependency,
        ITestComposer<TSut> testComposer
    );
    
    IValueDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentDependency,
        TNewDependency dependency,
        ITestComposer<TSut> testComposer
    )
        where TCurrentDependency : class;
    
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        TNewDependency dependency,
        string name,
        ITestComposer<TSut> testComposer
        )
        where TNewDependency : class;
    
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> mock,
        TNewDependency newDependency,
        string name,
        ITestComposer<TSut> testComposer
    )
        where TCurrentDependency : class;
    
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        string currentDependencyName,
        TNewDependency newDependency,
        string newDependencyName,
        ITestComposer<TSut> testComposer
    );

    IMockDependencyBuilder<TSut, TNewDependency> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        ITestComposer<TSut> testComposer
        )
            where TNewDependency : class;
    
    IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> currentDependency,
        ITestComposer<TSut> testComposer
    )
        where TCurrentDependency : class;
}
