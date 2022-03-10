namespace XpressTest;

public class NamedObjectSetter<TObject>
    :
        INamedObjectSetter<TObject>
{
    private readonly IArrangement _arrangement;

    public NamedObjectSetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(INamedObject<TObject> namedObject)
    {
        _arrangement.Add(namedObject);
    }
}