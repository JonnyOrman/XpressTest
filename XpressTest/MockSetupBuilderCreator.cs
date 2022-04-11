namespace XpressTest;

public class MockSetupBuilderCreator<TSut>
:
    IMockSetupBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;
    private INamedMockSetupBuilderCreator<TSut> _namedMockSetupBuilderGenerator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public MockSetupBuilderCreator(
        IArrangement arrangement,
        IAsserterCreator<TSut> asserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator,
        INamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderGenerator,
        ISutAsserterCreator<TSut> sutAsserterCreator
        )
    {
        _arrangement = arrangement;
        _asserterCreator = asserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _dependencyBuilderCreator = dependencyBuilderCreator;
        _namedMockSetupBuilderGenerator = namedMockSetupBuilderGenerator;
        _sutAsserterCreator = sutAsserterCreator;
    }
    
    public IMockSetupBuilder<TSut, TObject> Create<TObject>()
        where TObject : class
    {
        var moqMock = new Moq.Mock<TObject>();

        var mock = new Mock<TObject>(moqMock);
        
        var setter = new MockObjectSetter<TObject>(
            _arrangement
        );
        
        var chainer = new MockVariableBuilderChainer<TSut, TObject, IMock<TObject>>(
            _asserterCreator,
            this,
            _objectBuilderCreator,
            _arrangement,
            _dependencyBuilderCreator,
            _namedMockSetupBuilderGenerator,
            _sutAsserterCreator
        ); 
        
        return new MockSetupBuilder<TSut, TObject, IMock<TObject>>(
            mock,
            setter,
            chainer
        );
    }

    public void Set(NamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderGenerator)
    {
        _namedMockSetupBuilderGenerator = namedMockSetupBuilderGenerator;
    }
    
    public void Set(IObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
}