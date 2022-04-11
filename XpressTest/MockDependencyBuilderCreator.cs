namespace XpressTest;

public class MockDependencyBuilderCreator<TSut>
    :
        IMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IMoqMockDependencyBuilderCreator<TSut> _moqMockDependencyBuilderCreator;

    public MockDependencyBuilderCreator(
        IArrangement arrangement,
        IMoqMockDependencyBuilderCreator<TSut> moqMockDependencyBuilderCreator
        )
    {
        _arrangement = arrangement;
        _moqMockDependencyBuilderCreator = moqMockDependencyBuilderCreator;
    }
    
    public IMockDependencySetupBuilder<TSut, TDependency> Create<TDependency>()
        where TDependency : class
    {
        var moqMock = new Moq.Mock<TDependency>();

        var mock = new Mock<TDependency>(moqMock);
        
        return _moqMockDependencyBuilderCreator.Create(
            mock
            );
    }

    public IMockDependencySetupBuilder<TSut, TDependency> CreateExisting<TDependency>() where TDependency : class
    {
        var mock = _arrangement.GetTheMock<TDependency>();
        
        return _moqMockDependencyBuilderCreator.Create(
            mock
        );
    }
}