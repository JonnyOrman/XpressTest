namespace XpressTest;

public class NamedMockDependencySetter<TDependency>
    :
        IObjectSetter<INamedMock<TDependency>>
where TDependency : class
{
    private readonly IArrangement _arrangement;

    public NamedMockDependencySetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(INamedMock<TDependency> obj)
    {
        _arrangement.AddDependency(
            obj.Object,
            obj.Name
        );
        
        _arrangement.Add(obj);
    }
}