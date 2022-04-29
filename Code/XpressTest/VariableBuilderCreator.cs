namespace XpressTest;

public class VariableBuilderCreator<TSut>
    :
        IVariableBuilderCreator<TSut>
where TSut : class
{
    private readonly ITestBuilderContainer<TSut> _testBuilderContainer;
    private readonly IArrangement _arrangement;
    private readonly IMockSetupBuilderCreator<TSut> _mockSetupBuilderGenerator;
    private readonly INamedMockSetupBuilderCreator<TSut> _namedMockSetupBuilderGenerator;

    public VariableBuilderCreator(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IArrangement arrangement,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderGenerator,
        INamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderGenerator
        )
    {
        _testBuilderContainer = testBuilderContainer;
        _arrangement = arrangement;
        _mockSetupBuilderGenerator = mockSetupBuilderGenerator;
        _namedMockSetupBuilderGenerator = namedMockSetupBuilderGenerator;
    }

    public IVariableBuilder<TSut> Create<TObject>(TObject obj)
    {
        var objectSetter = new ObjectSetter<TObject>(
            _arrangement
        );

        var namedObjectBuilderChainer = new VariableBuilderChainer<TSut>(
            _testBuilderContainer,
            _mockSetupBuilderGenerator,
            _namedMockSetupBuilderGenerator
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
            _testBuilderContainer,
            _mockSetupBuilderGenerator,
            _namedMockSetupBuilderGenerator
        );

        return new VariableBuilder<TSut, INamedObject<TObject>, IVariableBuilderChainer<TSut>>(
            newNamedObject,
            namedObjectSetter,
            namedObjectBuilderChainer
        );
    }

    public IVariableBuilder<TSut> Create<TObject>(
        Func<IReadArrangement, TObject> func
        )
    {
        var newObject = func.Invoke(_arrangement);

        return Create(newObject);
    }

    public IVariableBuilder<TSut> Create<TObject>(
        Func<IReadArrangement, TObject> func,
        string name
        )
    {
        var newObject = func.Invoke(_arrangement);

        return Create(newObject, name);
    }
}