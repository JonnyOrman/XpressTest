namespace XpressTest;

public class DependencyBuilderChainer<TSut>
    :
        IDependencyBuilderChainer<TSut>
where TSut : class
{
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    private readonly IAsserterCreator<TSut> _asserterCreator;

    private readonly IValueDependencyBuilderCreator<TSut> _valueDependencyBuilderCreator;
    private readonly IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;

    public DependencyBuilderChainer(
        ISutAsserterCreator<TSut> sutAsserterCreator,
        IAsserterCreator<TSut> asserterCreator,
        IValueDependencyBuilderCreator<TSut> valueDependencyBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator
    )
    {
        _sutAsserterCreator = sutAsserterCreator;
        _asserterCreator = asserterCreator;
        _valueDependencyBuilderCreator = valueDependencyBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }

    public IValueDependencyBuilder<TSut> ComposeDependencyBuilder<TNewDependency>(
        TNewDependency newDependency
    )
    {
        return _valueDependencyBuilderCreator.Create(
            newDependency
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> ComposeMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class
    {
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }

    public ISutAsserter<TSut> ComposeAsserter()
    {
        return _sutAsserterCreator.Create();
    }

    public IVoidAsserter<TSut> ComposeAsserter(
        System.Action<TSut> action
        )
    {
        return _asserterCreator.CreateVoidAsserter(
            action
        );
    }
}