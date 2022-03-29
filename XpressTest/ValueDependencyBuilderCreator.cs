namespace XpressTest;

public class ValueDependencyBuilderCreator<TSut>
    :
        IValueDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;
    private readonly INamedMockDependencyBuilderCreator<TSut> _namedMockDependencyBuilderCreator;

    public ValueDependencyBuilderCreator(
        IArrangement arrangement,
        ISutAsserterCreator<TSut> sutAsserterCreator,
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator
        )
    {
        _arrangement = arrangement;
        _sutAsserterCreator = sutAsserterCreator;
        _voidAsserterCreator = voidAsserterCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
    }

    public IValueDependencyBuilder<TSut> Create<TDependency>(TDependency dependency)
    {
        var valueDependencySetter = ValueDependencySetterInitialiser<TDependency>.Initialise(
            _arrangement
        );

        var valueDependencyBuilderChainer = ValueDependencyBuilderChainerInitialiser<TSut>.Initialise(
            _sutAsserterCreator,
            _voidAsserterCreator,
            _mockDependencyBuilderCreator,
            _namedMockDependencyBuilderCreator
        );
        
        return new ValueDependencyBuilder<TSut, TDependency>(
            dependency,
            valueDependencySetter,
            valueDependencyBuilderChainer
        );
    }

    public IValueDependencyBuilder<TSut> Create<TDependency>(
        Func<IArrangement, TDependency> dependencyFunc
        )
    {
        var dependency = dependencyFunc.Invoke(_arrangement);
        
        var valueDependencySetter = ValueDependencySetterInitialiser<TDependency>.Initialise(
            _arrangement
        );
        
        var valueDependencyBuilderChainer = ValueDependencyBuilderChainerInitialiser<TSut>.Initialise(
            _sutAsserterCreator,
            _voidAsserterCreator,
            _mockDependencyBuilderCreator,
            _namedMockDependencyBuilderCreator
        );
        
        return new ValueDependencyBuilder<TSut, TDependency>(
            dependency,
            valueDependencySetter,
            valueDependencyBuilderChainer
        );
    }

    public void Set(IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator)
    {
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
}