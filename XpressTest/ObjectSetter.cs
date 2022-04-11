namespace XpressTest;

public class ObjectSetter<TObject>
    :
        ArrangementSetter<TObject>
{
    public ObjectSetter(
        IArrangement arrangement
    ) : base(
        arrangement,
        (arrangement, obj) => arrangement.Add(obj)
    )
    {
    }
}