namespace XpressTest;

public class VariableBuilderChainer<TSut>
    :
        BuilderChainer<TSut>,
        IVariableBuilderChainer<TSut>
where TSut : class
{
    private IMockSetupBuilderCreator<TSut> _mockObjectBuilderGenerator;
    private readonly INamedMockSetupBuilderCreator<TSut> _namedMockObjectBuilderGenerator;

    public VariableBuilderChainer(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IMockSetupBuilderCreator<TSut> mockObjectBuilderGenerator,
        INamedMockSetupBuilderCreator<TSut> namedMockObjectBuilderGenerator
        )
        :
        base(
            testBuilderContainer
        )
    {
        _mockObjectBuilderGenerator = mockObjectBuilderGenerator;
        _namedMockObjectBuilderGenerator = namedMockObjectBuilderGenerator;
    }
    
    public IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        TNewDependency newObject,
        string name
        )
    {
        return _testBuilderContainer.VariableBuilderCreator.Create(
            newObject,
            name
            );
    }

    public IVariableBuilder<TSut> StartNewNamedObjectBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> func,
        string name
        )
    {
        return _testBuilderContainer.VariableBuilderCreator.Create(
            func,
            name
        );
    }

    public IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        TNewObject newObject
        )
    {
        return _testBuilderContainer.VariableBuilderCreator.Create(
            newObject
        );
    }

    public IVariableBuilder<TSut> StartNewObjectBuilder<TNewObject>(
        Func<IReadArrangement, TNewObject> func
        )
    {
        return _testBuilderContainer.VariableBuilderCreator.Create(
            func
        );
    }

    public IMockSetupBuilder<TSut, TNewObject> StartNewMockObjectBuilder<TNewObject>()
        where TNewObject : class
    {
        return _mockObjectBuilderGenerator.Create<TNewObject>();
    }

    public IDependencyBuilder<TSut> ComposeValueDependencyBuilder<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    )
    {
        return _testBuilderContainer.DependencyBuilderCreator.CreateObjectDependencyBuilder(
            newDependencyFunc
        );
    }

    public IMockSetupBuilder<TSut, TNewObject> StartNewNamedMockObjectBuilder<TNewObject>(
        string name
        )
        where TNewObject : class
    {
        return _namedMockObjectBuilderGenerator.Create<TNewObject>(
            name
            );
    }
}