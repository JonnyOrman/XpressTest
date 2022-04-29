namespace XpressTest;

public class NamedMockDependencyBuilderCreator<TSut>
    :
        INamedMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IDependencyBuilderChainer<TSut> _mockDependencyBuilderChainer;

    public NamedMockDependencyBuilderCreator(
        IArrangement arrangement,
        IDependencyBuilderChainer<TSut> mockDependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
        _mockDependencyBuilderChainer = mockDependencyBuilderChainer;
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
}