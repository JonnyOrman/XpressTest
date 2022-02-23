namespace XpressTest;

public class ObjectCollection : IObjectCollection
{
    private readonly IDictionary<string, object> _dictionary;
    private readonly ICollection<object> _collection;

    public ObjectCollection()
    {
        _dictionary = new Dictionary<string, object>();
        _collection = new List<object>();
    }
    
    public T Get<T>(string name)
    {
        if(_dictionary[name] is T obj)
        {
            return obj;
        }

        throw new Exception($"Object {name} is not of type {typeof(T).Name}");
    }

    public T Get<T>()
    {
        foreach (var obj in _collection)
        {
            if (obj is T typedObject)
            {
                return typedObject;
            }
        }

        throw new Exception($"No unnamed object of type {typeof(T).Name} registered");
    }

    public void Add<T>(INamedObject<T> namedObject)
    {
        _dictionary[namedObject.Name] = namedObject.Object;
    }

    public void Add<T>(T obj)
    {
        foreach (var existingObject in _collection)
        {
            if (existingObject is T typedObject)
            {
                throw new Exception(
                    $"An unnamed object of type {typeof(T).Name} has already been registered. Each object of the same type must be registered with a unique name.");
            }
        }

        _collection.Add(obj);
    }
}