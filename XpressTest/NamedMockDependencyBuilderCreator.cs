using Moq;

namespace XpressTest;

public class NamedMockDependencyBuilderCreator<TSut>
    :
        INamedMockDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly INamedMockDependencyBuilderChainer<TSut> _namedMockDependencyBuilderChainer;
    private readonly IArrangement _arrangement;

    public NamedMockDependencyBuilderCreator(
        INamedMockDependencyBuilderChainer<TSut> namedMockDependencyBuilderChainer,
        IArrangement arrangement
        )
    {
        _namedMockDependencyBuilderChainer = namedMockDependencyBuilderChainer;
        _arrangement = arrangement;
    }
    
    public INamedMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        string dependencyName
        )
        where TDependency : class
    {
        var newMock = new Mock<TDependency>();

        var namedMock = new NamedMock<TDependency>(
            newMock,
            dependencyName
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