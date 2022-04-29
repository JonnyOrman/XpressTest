namespace XpressTest;

public class ExistingObjectDependencyBuilderCreator<TSut>
:
    IExistingObjectDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly ITestBuilderContainer<TSut> _testBuilderContainer;

    private readonly IArrangement _arrangement;

    public ExistingObjectDependencyBuilderCreator(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IArrangement arrangement
        )
    {
        _testBuilderContainer = testBuilderContainer;
        _arrangement = arrangement;
    }

    public IDependencyBuilder<TSut> Create<TDependency>()
    {
        var dependency = _arrangement.GetThe<TDependency>();

        return Create(dependency);
    }

    public IDependencyBuilder<TSut> Create<TDependency>(string name)
    {
        var dependency = _arrangement.GetThe<TDependency>(name);

        return Create(dependency);
    }

    private IDependencyBuilder<TSut> Create<TDependency>(TDependency dependency)
    {
        var setter = new ExistingObjectDependencySetter<TDependency>(
            _arrangement
        );

        var chainer = new DependencyBuilderChainer<TSut>(
            _arrangement,
            _testBuilderContainer
        );

        return new DependencyBuilder<TSut, TDependency>(
            dependency,
            setter,
            chainer
        );
    }
}