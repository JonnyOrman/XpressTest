namespace XpressTest;

public class VariableBuilderChainer<TSut>
    :
        BuilderChainer<TSut>,
        IVariableBuilderChainer<TSut>
where TSut : class
{
    private readonly IMockSetupBuilderCreator<TSut> _mockObjectBuilderCreator;
    private readonly INamedMockSetupBuilderCreator<TSut> _namedMockObjectBuilderCreator;

    public VariableBuilderChainer(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IMockSetupBuilderCreator<TSut> mockObjectBuilderCreator,
        INamedMockSetupBuilderCreator<TSut> namedMockObjectBuilderCreator
        )
        :
        base(
            testBuilderContainer
        )
    {
        _mockObjectBuilderCreator = mockObjectBuilderCreator;
        _namedMockObjectBuilderCreator = namedMockObjectBuilderCreator;
    }
    
    public IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        TNewDependency newObject,
        string name
        )
    {
        return TestBuilderContainer.VariableBuilderCreator.Create(
            newObject,
            name
            );
    }

    public IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> func,
        string name
        )
    {
        return TestBuilderContainer.VariableBuilderCreator.Create(
            func,
            name
        );
    }

    public IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
        )
    {
        return TestBuilderContainer.VariableBuilderCreator.Create(
            newObject
        );
    }

    public IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        Func<IReadArrangement, TNewObject> func
        )
    {
        return TestBuilderContainer.VariableBuilderCreator.Create(
            func
        );
    }

    public IMockSetupBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        return _mockObjectBuilderCreator.Create<TNewObject>();
    }

    public IDependencyBuilder<TSut> StartExistingObjectDependencyBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    )
    {
        return TestBuilderContainer.DependencyBuilderCreator.CreateObjectDependencyBuilder(
            newDependencyFunc
        );
    }

    public IMockSetupBuilder<TSut, TNewObject> StartNewNamedMockObjectBuilder<TNewObject>(
        string name
        )
        where TNewObject : class
    {
        return _namedMockObjectBuilderCreator.Create<TNewObject>(
            name
            );
    }
}