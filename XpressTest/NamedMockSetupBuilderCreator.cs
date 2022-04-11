namespace XpressTest;

public class NamedMockSetupBuilderCreator<TSut>
:
    INamedMockSetupBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private IMockSetupBuilderCreator<TSut> _mockSetupBuilderGenerator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public NamedMockSetupBuilderCreator(
        IArrangement arrangement,
        IAsserterCreator<TSut> asserterCreator,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderGenerator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator,
        ISutAsserterCreator<TSut> sutAsserterCreator
        )
    {
        _arrangement = arrangement;
        _asserterCreator = asserterCreator;
        _mockSetupBuilderGenerator = mockSetupBuilderGenerator;
        _objectBuilderCreator = objectBuilderCreator;
        _dependencyBuilderCreator = dependencyBuilderCreator;
        _sutAsserterCreator = sutAsserterCreator;
    }
    
    public IMockSetupBuilder<TSut, TObject> Create<TObject>(string name)
        where TObject : class
    {
        var moqMock = new Moq.Mock<TObject>();

        var mock = new NamedMock<TObject>(
            moqMock,
            name
            );
        
        var setter = new NamedMockObjectSetter<TObject>(
            _arrangement
        );
        
        var chainer = new MockVariableBuilderChainer<TSut, TObject, INamedMock<TObject>>(
            _asserterCreator,
            _mockSetupBuilderGenerator,
            _objectBuilderCreator,
            _arrangement,
            _dependencyBuilderCreator,
            this,
            _sutAsserterCreator
        );

        return new MockSetupBuilder<TSut, TObject, INamedMock<TObject>>(
            mock,
            setter,
            chainer
        );
    }

    public void Set(ObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
}