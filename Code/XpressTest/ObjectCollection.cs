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

            if (obj.GetType() == typeof(T))
            {
                var typedObj = (T)obj;

                return typedObj;
            }
            else
            {
                throw new NamedObjectDifferentTypeRegisteredException<T>(name, obj.GetType());
            }
        }

        throw new NamedObjectNotRegisteredException<T>(name);
    }

    public T Get<T>()
    {
        foreach (var obj in _collection)
        {
            if (obj.GetType() == typeof(T))
            {
                var typedObj = (T)obj;

                return typedObj;
            }
        }

        throw new ObjectNotRegisteredException<T>();
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
                throw new UnnamedObjectTypeAlreadyRegisteredException<T>();
            }
        }

        _collection.Add(obj);
    }
}