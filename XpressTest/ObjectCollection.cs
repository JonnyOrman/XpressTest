namespace XpressTest;

public class ObjectCollection : IObjectCollection
{
    private readonly IDictionary<string, object> _dictionary;

    public ObjectCollection()
    {
        _dictionary = new Dictionary<string, object>();
    }
    
    public T Get<T>(string name)
    {
        if(_dictionary[name] is T obj)
        {
            return obj;
        }

        throw new Exception($"Object {name} is not of type {typeof(T).Name}");
    }

    public void Add<T>(INamedObject<T> namedObject)
    {
        _dictionary[namedObject.Name] = namedObject.Object;
    }
}