namespace XpressTest;

public class ExistingObjectDependencyBuilderCreator<TSut>
:
    IExistingObjectDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly IAsserterCreator<TSut> _asserterCreator;
    private IObjectBuilderCreator<TSut> _objectBuilderCreator;
    private readonly IDependencyBuilderCreator<TSut> _dependencyBuilderCreator;
    private readonly ISutAsserterCreator<TSut> _sutAsserterCreator;

    public ExistingObjectDependencyBuilderCreator(
        IArrangement arrangement,
        IAsserterCreator<TSut> asserterCreator,
        IObjectBuilderCreator<TSut> objectBuilderCreator,
        IDependencyBuilderCreator<TSut> dependencyBuilderCreator,
        ISutAsserterCreator<TSut> sutAsserterCreator
        )
    {
        _arrangement = arrangement;
        _asserterCreator = asserterCreator;
        _objectBuilderCreator = objectBuilderCreator;
        _dependencyBuilderCreator = dependencyBuilderCreator;
        _sutAsserterCreator = sutAsserterCreator;
    }
    
    public IDependencyBuilder<TSut> Create<TDependency>()
    {
        var dependency = _arrangement.GetThe<TDependency>();

        var setter = new ExistingObjectDependencySetter<TDependency>(
            _arrangement
            );

        var chainer = new DependencyBuilderChainer<TSut>(
            _asserterCreator,
            _objectBuilderCreator,
            _arrangement,
            _dependencyBuilderCreator,
            _sutAsserterCreator
            );
        
        return new DependencyBuilder<TSut, TDependency>(
            dependency,
            setter,
            chainer
            );
    }

    public IDependencyBuilder<TSut> Create<TDependency>(string name)
    {
        var dependency = _arrangement.GetThe<TDependency>(name);

        var setter = new ExistingObjectDependencySetter<TDependency>(
            _arrangement
        );

        var chainer = new DependencyBuilderChainer<TSut>(
            _asserterCreator,
            _objectBuilderCreator,
            _arrangement,
            _dependencyBuilderCreator,
            _sutAsserterCreator
        );
        
        return new DependencyBuilder<TSut, TDependency>(
            dependency,
            setter,
            chainer
        );
    }

    public void Set(ObjectBuilderCreator<TSut> objectBuilderCreator)
    {
        _objectBuilderCreator = objectBuilderCreator;
    }
}