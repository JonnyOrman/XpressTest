using Moq;

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
    
    public IMockDependencyBuilder<TSut, TDependency> Create<TDependency>()
        where TDependency : class
    {
        var mock = new Mock<TDependency>();

        return _moqMockDependencyBuilderCreator.Create(
            mock
            );
    }

    public INamedMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        string name
        )
        where TDependency : class
    {
        var newMock = new Mock<TDependency>();
        
        return _moqMockDependencyBuilderCreator.Create(
            newMock,
            name
        );
    }
    
    public IMockDependencyBuilder<TSut, TDependency> CreateExisting<TDependency>() where TDependency : class
    {
        var mock = _arrangement.GetMock<TDependency>();
        
        return _moqMockDependencyBuilderCreator.Create(
            mock
        );
    }
}