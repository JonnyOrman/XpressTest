namespace XpressTest;

public class DependencyBuilderCreator<TSut>
    :
        IDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IObjectDependencyBuilderCreator<TSut> _objectDependencyBuilderCreator;
    private readonly INamedDependencyBuilderCreator<TSut> _namedDependencyBuilderCreator;
    private readonly IMockTypeDependencyBuilderCreator<TSut> _mockTypeDependencyBuilderCreator;
    private readonly INamedMockDependencyBuilderCreator<TSut> _namedMockDependencyBuilderCreator;
    private readonly IExistingObjectDependencyBuilderCreator<TSut> _existingObjectDependencyBuilderCreator;

    public DependencyBuilderCreator(
        IObjectDependencyBuilderCreator<TSut> objectDependencyBuilderCreator,
        INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator,
        IMockTypeDependencyBuilderCreator<TSut> mockTypeDependencyBuilderCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator,
        IExistingObjectDependencyBuilderCreator<TSut> existingObjectDependencyBuilderCreator
        )
    {
        _objectDependencyBuilderCreator = objectDependencyBuilderCreator;
        _namedDependencyBuilderCreator = namedDependencyBuilderCreator;
        _mockTypeDependencyBuilderCreator = mockTypeDependencyBuilderCreator;
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
        _existingObjectDependencyBuilderCreator = existingObjectDependencyBuilderCreator;
    }

    public IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(
        TNewDependency newDependency,
        string newDependencyName)
    {
        return _namedDependencyBuilderCreator.Create(
            newDependency,
            newDependencyName
            );
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> CreateMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _mockTypeDependencyBuilderCreator.Create<TNewDependency>();
    }

    public IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
        )
    {
        return _objectDependencyBuilderCreator.Create(newDependency);
    }

    public IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
        )
    {
        return _objectDependencyBuilderCreator.Create(newDependencyFunc);
    }

    public IMockDependencySetupBuilder<TSut, TNewDependency> CreateMockDependencyBuilder<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return _namedMockDependencyBuilderCreator.Create<TNewDependency>(name);
    }

    public IMockDependencySetupBuilder<TSut, TMock> CreateExistingMockDependencyBuilder<TMock>()
        where TMock : class
    {
        return _mockTypeDependencyBuilderCreator.CreateExisting<TMock>();
    }

    public IDependencyBuilder<TSut> Create<TObject>()
    {
        return _existingObjectDependencyBuilderCreator.Create<TObject>();
    }

    public IDependencyBuilder<TSut> Create<TObject>(string name)
    {
        return _existingObjectDependencyBuilderCreator.Create<TObject>(name);
    }
}