namespace XpressTest;

public class MoqMockDependencyBuilderCreator<TSut>
:
    IMoqMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IDependencyBuilderChainer<TSut> _mockDependencyBuilderChainer;

    public MoqMockDependencyBuilderCreator(
        IArrangement arrangement,
        IDependencyBuilderChainer<TSut> mockDependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
        _mockDependencyBuilderChainer = mockDependencyBuilderChainer;
    }
    
    public IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>(
        IMock<TDependency> moqMock
        )
        where TDependency : class
    {
        var mockDependencySetter = new MockDependencySetter<TDependency>(
            _arrangement
        );
        
        return new MockDependencySetupBuilder<TSut, TDependency, IMock<TDependency>>(
            moqMock,
            _arrangement,
            mockDependencySetter,
            _mockDependencyBuilderChainer
        );
    }
}