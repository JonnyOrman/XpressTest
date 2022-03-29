namespace XpressTest;

public class NamedDependencyBuilderCreator<TSut>
    :
        INamedDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;

    public NamedDependencyBuilderCreator(
        IArrangement arrangement,
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator
        )
    {
        _arrangement = arrangement;
        _voidAsserterCreator = voidAsserterCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public IDependencyBuilder<TSut> Create<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        return new NamedDependencyBuilder<TSut, TNewDependency>(
            _arrangement,
            newDependency,
            name,
            _voidAsserterCreator,
            this,
            _mockDependencyBuilderCreator
        );
    }

    public void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
}