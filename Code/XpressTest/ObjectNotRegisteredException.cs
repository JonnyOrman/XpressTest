namespace XpressTest;

public class ObjectNotRegisteredException<TObject>
    :
        Exception
{
    public ObjectNotRegisteredException()
        :
        base($"No object of type {typeof(TObject).Name} registered")
    {
        ObjectType = typeof(TObject);
    }

    public Type ObjectType { get; }
}