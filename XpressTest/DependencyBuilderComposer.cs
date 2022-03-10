using Moq;

namespace XpressTest;

public class DependencyBuilderComposer<TSut>
    :
        IDependencyBuilderComposer<TSut>
    where TSut : class
{
    public IValueDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        TNewDependency dependency,
        ITestComposer<TSut> testComposer
        )
    {
        if (currentDependency != null)
        {
            var dependencyObject = new Dependency<TCurrentDependency>(currentDependency);

            testComposer.Arrangement.Dependencies.Add(dependencyObject);
        }

        return new ValueDependencyBuilder<TSut, TNewDependency>(
            dependency,
            testComposer
        );
    }

    public IValueDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> mock,
        TNewDependency dependency,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class
    {
        if (mock != null)
        {
            testComposer.Arrangement.MockObjects.Add(mock);
            
            testComposer.Arrangement.AddDependency(mock.Object);
        }

        return new ValueDependencyBuilder<TSut, TNewDependency>(
            dependency,
            testComposer
        );
    }

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
            var dependency = new NamedDependency<TCurrentDependency>(currentDependency, name);

            testComposer.Arrangement.Dependencies.Add(dependency);
        }

        return new DependencyBuilder<TSut, TNewDependency>(
            newDependency,
            testComposer
        );
    }

    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> mock,
        TNewDependency newDependency,
        string name,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class
    {
        if (mock != null)
        {
            testComposer.Arrangement.MockObjects.Add(mock);
            
            testComposer.Arrangement.AddDependency(mock.Object);
        }

        return new NamedDependencyBuilder<TSut, TNewDependency>(
            newDependency,
            name,
            testComposer
        );
    }

    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        TCurrentDependency currentDependency,
        string currentDependencyName,
        TNewDependency newDependency,
        string newDependencyName,
        ITestComposer<TSut> testComposer
        )
    {
        if (currentDependency != null)
        {
            var dependency = new NamedDependency<TCurrentDependency>(currentDependency, currentDependencyName);

            testComposer.Arrangement.Dependencies.Add(dependency);
        }

        return new NamedDependencyBuilder<TSut, TNewDependency>(
            newDependency,
            newDependencyName,
            testComposer
        );
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

        return new MockDependencyBuilder<TSut, TNewDependency>(
            new Mock<TNewDependency>(),
            testComposer
        );
    }

    public IDependencyBuilder<TSut> Compose<TCurrentDependency, TNewDependency>(
        Mock<TCurrentDependency> mock,
        ITestComposer<TSut> testComposer
        )
        where TCurrentDependency : class
    {
        if (mock != null)
        {
            testComposer.Arrangement.MockObjects.Add(mock);
            
            testComposer.Arrangement.AddDependency(mock.Object);
        }

        var newDependency = testComposer.Arrangement.GetThe<TNewDependency>();
        
        testComposer.Arrangement.AddDependency(newDependency);

        return new ExistingObjectBuilder<TSut>(
            testComposer
            );
    }
}
