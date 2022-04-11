namespace XpressTest;

public class ObjectDependencyBuilderCreator<TSut>
    :
        IObjectDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;

    public ObjectDependencyBuilderCreator(
        IArrangement arrangement,
        ISutAsserterCreator<TSut> sutAsserterCreator,
        IAsserterCreator<TSut> asserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator
        )
    {
        _arrangement = arrangement;
        _sutAsserterCreator = sutAsserterCreator;
        _asserterCreator = asserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _dependencyBuilderCreator = dependencyBuilderCreator;
    }

    public IDependencyBuilder<TSut> Create<TDependency>(TDependency dependency)
    {
        var valueDependencySetter = DependencySetterInitialiser<TDependency>.Initialise(
            _arrangement
        );

        var valueDependencyBuilderChainer = new DependencyBuilderChainer<TSut>(
            _asserterCreator,
            _objectBuilderCreator,
            _arrangement,
            _dependencyBuilderCreator,
            _sutAsserterCreator
        );
        
        return new DependencyBuilder<TSut, TDependency>(
            dependency,
            valueDependencySetter,
            valueDependencyBuilderChainer
        );
    }

    public IDependencyBuilder<TSut> Create<TDependency>(
        Func<IReadArrangement, TDependency> dependencyFunc
        )
    {
        var dependency = dependencyFunc.Invoke(_arrangement);

        return Create(dependency);
    }
    
    public void Set(IObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
}