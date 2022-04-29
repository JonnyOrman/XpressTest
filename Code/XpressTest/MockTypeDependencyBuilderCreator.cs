namespace XpressTest;

public class MockTypeDependencyBuilderCreator<TSut>
    :
        IMockTypeDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;

    public MockTypeDependencyBuilderCreator(
        IArrangement arrangement,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator
        )
    {
        _arrangement = arrangement;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }

    public IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>()
        where TDependency : class
    {
        var moqMock = new Moq.Mock<TDependency>();

        var mock = new Mock<TDependency>(moqMock);

        return _mockDependencyBuilderCreator.Create(
            mock
            );
    }

    public IMockDependencySetupBuilder<TSut, TDependency> CreateExisting<TDependency>()
        where TDependency : class
    {
        var mock = _arrangement.GetTheMock<TDependency>();

        return _mockDependencyBuilderCreator.Create(
            mock
        );
    }
}