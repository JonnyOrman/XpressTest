namespace XpressTest;

public class NamedDependencyBuilder<TSut, TDependency>
    : 
        INamedDependencyBuilder<TSut>
where TSut : class
{
    private readonly IArrangement _arrangement;
    private readonly TDependency _dependency;
    private readonly string _name;
    private readonly IVoidAsserterCreator<TSut> _voidAsserterCreator;
    private readonly INamedDependencyBuilderCreator<TSut> _namedDependencyBuilderCreator;
    private readonly IMockDependencyBuilderCreator<TSut> _mockDependencyBuilderCreator;

    public NamedDependencyBuilder(
        IArrangement arrangement,
        TDependency dependency,
        string name,
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator
        )
    {
        _arrangement = arrangement;
        _dependency = dependency;
        _name = name;
        _voidAsserterCreator = voidAsserterCreator;
        _namedDependencyBuilderCreator = namedDependencyBuilderCreator;
        _mockDependencyBuilderCreator = mockDependencyBuilderCreator;
    }
    
    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        _arrangement.AddDependency(_dependency);
        
        return _voidAsserterCreator.Create(
            action
        );
    }

    public INamedDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        var dependency = new NamedDependency<TDependency>(_dependency, _name);

        _arrangement.Dependencies.Add(dependency);

        return _namedDependencyBuilderCreator.Create(
            newDependency,
            name
            );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        var dependency = new NamedDependency<TDependency>(
            _dependency,
            _name
        );

        _arrangement.Dependencies.Add(dependency);
        
        return _mockDependencyBuilderCreator.Create<TNewDependency>();
    }
}