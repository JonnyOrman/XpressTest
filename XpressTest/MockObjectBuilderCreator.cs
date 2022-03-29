using Moq;

namespace XpressTest;

public class MockObjectBuilderCreator<TSut>
    :
        IMockObjectBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private readonly INamedMockDependencyBuilderCreator<TSut> _namedMockDependencyBuilderCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;

    public MockObjectBuilderCreator(
        IArrangement arrangement,
        ISutAsserterCreator<TSut> sutAsserterCreator,
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator
        )
    {
        _arrangement = arrangement;
        _sutAsserterCreator = sutAsserterCreator;
        _voidAsserterCreator = voidAsserterCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public IMockObjectBuilder<TSut, TNewObject> Create<TNewObject>()
        where TNewObject : class
    {
        var newMock = new Mock<TNewObject>();

        var mockObjectSetter = new MockObjectSetter<TNewObject>(
            _arrangement
        );

        var valueDependencyBuilderCreator = new ValueDependencyBuilderCreator<TSut>(
            _arrangement,
            _sutAsserterCreator,
            _voidAsserterCreator,
            _mockDependencyBuilderCreator,
            _namedMockDependencyBuilderCreator
        );
        
        var mockObjectBuilderChainer = new MockObjectBuilderChainer<TSut>(
            valueDependencyBuilderCreator,
            _mockDependencyBuilderCreator,
            this,
            _objectBuilderCreator
        );
        
        return new MockObjectBuilder<TSut, TNewObject>(
            newMock,
            mockObjectSetter,
            mockObjectBuilderChainer,
            _arrangement
        );
    }

    public void Set(ObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
    
    public void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
}