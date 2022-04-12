namespace XpressTest;

public class NamedDependencyBuilderCreator<TSut>
    :
        INamedDependencyBuilderCreator<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;

    private IDependencyBuilderChainer<TSut> _dependencyBuilderChainer;

    public NamedDependencyBuilderCreator(
        IArrangement arrangement,
        IDependencyBuilderChainer<TSut> dependencyBuilderChainer
        )
    {
        _arrangement = arrangement;
        _dependencyBuilderChainer = dependencyBuilderChainer;
    }
    
    public IDependencyBuilder<TSut> Create<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
    {
        var namedDependency = new NamedDependency<TNewDependency>(
            newDependency,
            name
        );

        var setter = new NameDependencySetter<TNewDependency>(
            _arrangement
            );
        
        return new DependencyBuilder<TSut, INamedDependency>(
            namedDependency,
            setter,
            _dependencyBuilderChainer
        );
    }
}