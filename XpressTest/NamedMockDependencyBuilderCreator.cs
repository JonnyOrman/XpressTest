namespace XpressTest;

public class NamedMockDependencyBuilderCreator<TSut>
    :
        INamedMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private IDependencyBuilderChainer<TSut> _mockDependencyBuilderChainer;
    private readonly IArrangement _arrangement;

    public NamedMockDependencyBuilderCreator(
        IDependencyBuilderChainer<TSut> mockDependencyBuilderChainer,
        IArrangement arrangement
        )
    {
        _mockDependencyBuilderChainer = mockDependencyBuilderChainer;
        _arrangement = arrangement;
    }
    
    public IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>(
        string dependencyName
        )
        where TDependency : class
    {
        var newMock = new Moq.Mock<TDependency>();
        
        var namedMock = new NamedMock<TDependency>(
            newMock,
            dependencyName
        );
        
        var objectSetter = new NamedMockDependencySetter<TDependency>(
            _arrangement
        );
        
        return new MockDependencySetupBuilder<TSut, TDependency, INamedMock<TDependency>>(
            namedMock,
            _arrangement,
            objectSetter,
            _mockDependencyBuilderChainer
        );
    }

    public void Set(DependencyBuilderChainer<TSut> mockDependencyBuilderChainer)
    {
        _mockDependencyBuilderChainer = mockDependencyBuilderChainer;
    }
}