namespace XpressTest;

public class DependencySetter<TDependency>
:
    IObjectSetter<TDependency>
{
    private readonly IArrangement _arrangement;

    public DependencySetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(TDependency obj)
    {
        var dependencyObject = new Dependency<TDependency>(obj);
        _arrangement.Dependencies.Add(dependencyObject);
    }
}