namespace XpressTest;

public class ValueSetter<TDependency> : IObjectSetter<TDependency>
{
    private readonly IArrangement _arrangement;

    public ValueSetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(TDependency obj)
    {
        _arrangement.AddDependency(obj);
    }
}