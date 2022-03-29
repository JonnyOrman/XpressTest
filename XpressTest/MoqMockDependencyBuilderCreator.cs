using Moq;

namespace XpressTest;

public class MoqMockDependencyBuilderCreator<TSut>
:
    IMoqMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IMockDependencyBuilderChainer<TSut> _mockDependencyBuilderChainer;
    private readonly INamedMockDependencyBuilderChainer<TSut> _namedMockDependencyBuilderChainer;

    public MoqMockDependencyBuilderCreator(
        IArrangement arrangement,
        IMockDependencyBuilderChainer<TSut> mockDependencyBuilderChainer,
        INamedMockDependencyBuilderChainer<TSut> namedMockDependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
        _mockDependencyBuilderChainer = mockDependencyBuilderChainer;
        _namedMockDependencyBuilderChainer = namedMockDependencyBuilderChainer;
    }
    
    public IMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        Mock<TDependency> moqMock
        )
        where TDependency : class
    {
        var mockDependencySetter = new MockDependencySetter<TDependency>(
            _arrangement
        );
        
        return new MockDependencyBuilder<TSut, TDependency>(
            moqMock,
            mockDependencySetter,
            _mockDependencyBuilderChainer,
            _arrangement
        );
    }

    public INamedMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        Mock<TDependency> moqMock,
        string name
        )
        where TDependency : class
    {
        var namedMock = new NamedMock<TDependency>(
            moqMock,
            name
        );
        
        var objectSetter = new NamedMockDependencySetter<TDependency>(
            _arrangement
        );
        
        return new NamedMockDependencyBuilder<TSut, TDependency>(
            namedMock,
            objectSetter,
            _namedMockDependencyBuilderChainer,
            _arrangement
        );
    }
}