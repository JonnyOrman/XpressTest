namespace XpressTest;

public class NamedObjectNotRegisteredException<TObject>
    :
        Exception
{
    public NamedObjectNotRegisteredException(
        string name
    ) : base($"No object of type {typeof(TObject).Name} with name {name} registered")
    {
        ObjectType = typeof(TObject);
    }

    public Type ObjectType { get; }
}