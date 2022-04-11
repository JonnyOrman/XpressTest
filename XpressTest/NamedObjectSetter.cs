namespace XpressTest;

public class NamedObjectSetter<TObject>
    :
        ArrangementSetter<INamedObject<TObject>>
{
    public NamedObjectSetter(
        IArrangement arrangement
        ) : base(
        arrangement,
        (arrangement, namedObject) => arrangement.Add(namedObject)
    )
    {
    }
}