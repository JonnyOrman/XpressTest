namespace XpressTest;

public class ObjectCollection
    :
        IObjectCollection
{
    private readonly IDictionary<string, object> _dictionary;
    private readonly ICollection<object> _collection;

    public ObjectCollection(
        IDictionary<string, object> dictionary,
        ICollection<object> collection
        )
    {
        _dictionary = dictionary;
        _collection = collection;
    }
    
    public T Get<T>(string name)
    {
        if (_dictionary.Any() && _dictionary.ContainsKey(name))
        {
            var obj = _dictionary[name];

            if(obj.GetType() == typeof(T))
            {
                var typedObj = (T)obj;
                
                return typedObj;
            }
            else
            {
                throw new NamedObjectDifferentTypeRegisteredException($"Expected object with name {name} is not of type {typeof(T).Name}");
            }
        }

        throw new NamedObjectNotRegisteredException($"No object of type {typeof(T).Name} with name {name} registered");
    }

    public T Get<T>()
    {
        foreach (var obj in _collection)
        {
            if(obj.GetType() == typeof(T))
            {
                var typedObj = (T)obj;

                return typedObj;
            }
        }
        
        throw new ObjectNotRegisteredException($"No object of type {typeof(T).Name} registered");
    }

    public void Add<T>(INamedObject<T> namedObject)
    {
        _dictionary[namedObject.Name] = namedObject.Object;
    }

    public void Add<T>(T obj)
    {
        foreach (var existingObject in _collection)
        {
            if (existingObject.GetType() == typeof(T))
            {
                throw new UnnamedObjectTypeAlreadyRegisteredException(
                    $"An unnamed object of type {typeof(T).Name} has already been registered. Each object of the same type must be registered with a unique name.");
            }
        }

        _collection.Add(obj);
    }
}