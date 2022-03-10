namespace XpressTest;

public class ObjectSetter<TObject> : IObjectSetter<TObject>
{
    private readonly IArrangement _arrangement;

    public ObjectSetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(TObject obj)
    {
        _arrangement.Add(obj);
    }
}