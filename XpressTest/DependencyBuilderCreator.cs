namespace XpressTest;

public class DependencyBuilderCreator<TSut>
    :
        IDependencyBuilderCreator<TSut>
where TSut : class
{
    private IObjectDependencyBuilderCreator<TSut> _objectDependencyBuilderCreator;
    private INamedDependencyBuilderCreator<TSut> _namedDependencyBuilderCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private INamedMockDependencyBuilderCreator<TSut> _namedMockDependencyBuilderCreator;

    public DependencyBuilderCreator(
        IObjectDependencyBuilderCreator<TSut> objectDependencyBuilderCreator,
        INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator
        )
    {
        _objectDependencyBuilderCreator = objectDependencyBuilderCreator;
        _namedDependencyBuilderCreator = namedDependencyBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
    }

    public IDependencyBuilder<TSut> CreateNamedDependencyBuilder<TNewDependency>(TNewDependency newDependency,
        string newDependencyName)
    {
        return _namedDependencyBuilderCreator.Create(
            newDependency,
            newDependencyName
            );
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> CreateMockDependencyBuilder<TNewDependency>() where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }

    public IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(TNewDependency newDependency)
    {
        return _objectDependencyBuilderCreator.Create(newDependency);
    }

    public IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(Func<IReadArrangement, TNewDependency> newDependencyFunc)
    {
        return _objectDependencyBuilderCreator.Create(newDependencyFunc);
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> CreateNamedMockDependencyBuilder<TNewDependency>(string name) where TNewDependency : class
    {
        return _namedMockDependencyBuilderCreator.Create<TNewDependency>(name);
    }

    public IMockDependencySetupBuilder<TSut, TMock> CreateExistingMockDependencyBuilder<TMock>() where TMock : class
    {
        return _mockDependencyBuilderCreator.CreateExisting<TMock>();
    }

    public void Set(IObjectDependencyBuilderCreator<TSut> objectDependencyBuilderCreator)
    {
        _objectDependencyBuilderCreator = objectDependencyBuilderCreator;
    }
    
    public void Set(INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator)
    {
        _namedDependencyBuilderCreator = namedDependencyBuilderCreator;
    }
    
    public void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public void Set(INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator)
    {
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
    }
}