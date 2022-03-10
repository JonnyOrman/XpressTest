namespace XpressTest;

public interface INamedObjectSetter<TObject>
{
    void Set(INamedObject<TObject> namedObject);
}