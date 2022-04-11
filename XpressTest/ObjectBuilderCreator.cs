namespace XpressTest;

public class ObjectBuilderCreator<TSut>
    :
        IObjectBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IExistingObjectDependencyBuilderCreator<TSut> _existingObjectDependencyBuilderCreator;
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private readonly IMockSetupBuilderCreator<TSut> _mockSetupBuilderGenerator;
    private readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;
    private readonly INamedMockSetupBuilderCreator<TSut> _namedMockSetupBuilderGenerator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public ObjectBuilderCreator(
        IArrangement arrangement,
        IExistingObjectDependencyBuilderCreator<TSut> existingObjectDependencyBuilderCreator,
        IAsserterCreator<TSut> asserterCreator,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderGenerator,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator,
        INamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderGenerator,
        ISutAsserterCreator<TSut> sutAsserterCreator
        )
    {
        _arrangement = arrangement;
        _existingObjectDependencyBuilderCreator = existingObjectDependencyBuilderCreator;
        _asserterCreator = asserterCreator;
        _mockSetupBuilderGenerator = mockSetupBuilderGenerator;
        _dependencyBuilderCreator = dependencyBuilderCreator;
        _namedMockSetupBuilderGenerator = namedMockSetupBuilderGenerator;
        _sutAsserterCreator = sutAsserterCreator;
    }
    
    public IVariableBuilder<TSut> Create<TObject>(TObject obj)
    {
        var objectSetter = new ObjectSetter<TObject>(
            _arrangement
        );
        
        var namedObjectBuilderChainer = new VariableBuilderChainer<TSut>(
            _asserterCreator,
            this,
            _mockSetupBuilderGenerator,
            _dependencyBuilderCreator,
            _namedMockSetupBuilderGenerator,
            _sutAsserterCreator
        );

        return new VariableBuilder<TSut, TObject, IVariableBuilderChainer<TSut>>(
            obj,
            objectSetter,
            namedObjectBuilderChainer
        );
    }

    public IVariableBuilder<TSut> Create<TObject>(TObject obj, string name)
    {
        var namedObjectSetter = new NamedObjectSetter<TObject>(
            _arrangement
        );

        var newNamedObject = new NamedObject<TObject>(
            obj,
            name
            );
        
        var namedObjectBuilderChainer = new VariableBuilderChainer<TSut>(
            _asserterCreator,
            this,
            _mockSetupBuilderGenerator,
            _dependencyBuilderCreator,
            _namedMockSetupBuilderGenerator,
            _sutAsserterCreator
        );

        return new VariableBuilder<TSut, INamedObject<TObject>, IVariableBuilderChainer<TSut>>(
            newNamedObject,
            namedObjectSetter,
            namedObjectBuilderChainer
        );
    }

    public IDependencyBuilder<TSut> Create<TObject>()
    {
        return _existingObjectDependencyBuilderCreator.Create<TObject>();
    }

    public IDependencyBuilder<TSut> Create<TObject>(string name)
    {
        return _existingObjectDependencyBuilderCreator.Create<TObject>(name);
    }

    public IVariableBuilder<TSut> Create<TObject>(Func<IReadArrangement, TObject> func)
    {
        var newObject = func.Invoke(_arrangement);
        
        var objectSetter = new ObjectSetter<TObject>(
            _arrangement
        );

        var namedObjectBuilderChainer = new VariableBuilderChainer<TSut>(
            _asserterCreator,
            this,
            _mockSetupBuilderGenerator,
            _dependencyBuilderCreator,
            _namedMockSetupBuilderGenerator,
            _sutAsserterCreator
        );

        return new VariableBuilder<TSut, TObject, IVariableBuilderChainer<TSut>>(
            newObject,
            objectSetter,
            namedObjectBuilderChainer
        );
    }

    public IVariableBuilder<TSut> Create<TObject>(Func<IReadArrangement, TObject> func, string name)
    {
        var newObject = func.Invoke(_arrangement);
        
        var namedObjectSetter = new NamedObjectSetter<TObject>(
            _arrangement
        );

        var newNamedObject = new NamedObject<TObject>(
            newObject,
            name
            );
        
        var namedObjectBuilderChainer = new VariableBuilderChainer<TSut>(
            _asserterCreator,
            this,
            _mockSetupBuilderGenerator,
            _dependencyBuilderCreator,
            _namedMockSetupBuilderGenerator,
            _sutAsserterCreator
        );

        return new VariableBuilder<TSut, INamedObject<TObject>, IVariableBuilderChainer<TSut>>(
            newNamedObject,
            namedObjectSetter,
            namedObjectBuilderChainer
        );
    }
}