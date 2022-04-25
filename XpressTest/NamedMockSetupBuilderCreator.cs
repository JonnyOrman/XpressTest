namespace XpressTest;

public class NamedMockSetupBuilderCreator<TSut>
:
    INamedMockSetupBuilderCreator<TSut>
where TSut : class
{
    private readonly ITestBuilderContainer<TSut> _testBuilderContainer;
    private readonly IArrangement _arrangement;
    private IMockSetupBuilderCreator<TSut> _mockSetupBuilderGenerator;

    public NamedMockSetupBuilderCreator(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IArrangement arrangement,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderGenerator
        )
    {
        _testBuilderContainer = testBuilderContainer;
        _arrangement = arrangement;
        _mockSetupBuilderGenerator = mockSetupBuilderGenerator;
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
            _testBuilderContainer,
            _mockSetupBuilderGenerator,
            _arrangement,
            this
        );

        return new MockSetupBuilder<TSut, TObject, INamedMock<TObject>>(
            mock,
            setter,
            chainer
        );
    }
}