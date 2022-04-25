namespace XpressTest;

public class MockDependencyBuilderCreator<TSut>
:
    IMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IDependencyBuilderChainer<TSut> _mockDependencyBuilderChainer;

    public MockDependencyBuilderCreator(
        IArrangement arrangement,
        IDependencyBuilderChainer<TSut> mockDependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
        _mockDependencyBuilderChainer = mockDependencyBuilderChainer;
    }
    
    public IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>(
        IMock<TDependency> mock
        )
        where TDependency : class
    {
        var mockDependencySetter = new MockDependencySetter<TDependency>(
            _arrangement
        );
        
        return new MockDependencySetupBuilder<TSut, TDependency, IMock<TDependency>>(
            mock,
            _arrangement,
            mockDependencySetter,
            _mockDependencyBuilderChainer
        );
    }
}