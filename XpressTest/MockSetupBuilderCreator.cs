namespace XpressTest;

public class MockSetupBuilderCreator<TSut>
:
    IMockSetupBuilderCreator<TSut>
where TSut : class
{
    private readonly ITestBuilderContainer<TSut> _testBuilderContainer;

    private readonly IArrangement _arrangement;
    private INamedMockSetupBuilderCreator<TSut> _namedMockSetupBuilderGenerator;

    public MockSetupBuilderCreator(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IArrangement arrangement,
        INamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderGenerator
        )
    {
        _testBuilderContainer = testBuilderContainer;
        _arrangement = arrangement;
        _namedMockSetupBuilderGenerator = namedMockSetupBuilderGenerator;
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
            _testBuilderContainer,
            this,
            _arrangement,
            _namedMockSetupBuilderGenerator
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
}