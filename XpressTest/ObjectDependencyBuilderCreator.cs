namespace XpressTest;

public class ObjectDependencyBuilderCreator<TSut>
    :
        IObjectDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly ITestBuilderContainer<TSut> _testBuilderContainer;

    private readonly IArrangement _arrangement;

    public ObjectDependencyBuilderCreator(
        ITestBuilderContainer<TSut> testBuilderContainer,
        IArrangement arrangement
        )
    {
        _testBuilderContainer = testBuilderContainer;
        _arrangement = arrangement;
    }

    public IDependencyBuilder<TSut> Create<TDependency>(TDependency dependency)
    {
        var valueDependencySetter = DependencySetterInitialiser<TDependency>.Initialise(
            _arrangement
        );

        var valueDependencyBuilderChainer = new DependencyBuilderChainer<TSut>(
            _arrangement,
            _testBuilderContainer
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
}