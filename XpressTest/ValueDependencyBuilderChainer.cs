namespace XpressTest;

public class ValueDependencyBuilderChainer<TSut>
    :
        IValueDependencyBuilderChainer<TSut>
where TSut : class
{
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private readonly IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private readonly INamedMockDependencyBuilderCreator<TSut> _namedMockDependencyBuilderCreator;

    public ValueDependencyBuilderChainer(
        ISutAsserterCreator<TSut> sutAsserterCreator,
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator
        )
    {
        _sutAsserterCreator = sutAsserterCreator;
        _voidAsserterCreator = voidAsserterCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
    }
    
    public ISutAsserter<TSut> StartSutAsserter()
    {
        return _sutAsserterCreator.Create();
    }

    public IVoidAsserter<TSut> StartVoidAsserter(
        System.Action<TSut> func
        )
    {
        return _voidAsserterCreator.Create(
            func
            );
    }

    public IMockDependencyBuilder<TSut, TDependency> StartMockDependencyBuilder<TDependency>()
        where TDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TDependency>();
    }

    public IMockDependencyBuilder<TSut, TDependency> StartNamedMockDependencyBuilder<TDependency>(
        string dependencyName
        )
        where TDependency : class
    {
        return _namedMockDependencyBuilderCreator.Create<TDependency>(
            dependencyName
        );
    }
}