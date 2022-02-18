namespace XpressTest;

public class ObjectCollection : IObjectCollection
{
    private readonly IDictionary<string, IObject> _dictionary;

    public ObjectCollection()
    {
        _dictionary = new Dictionary<string, IObject>();
    }
    
    public T Get<T>(string name)
    {
        if(_dictionary[name].Obj is T obj)
        {
            return obj;
        }

        throw new Exception($"Object {name} is not of type {typeof(T).Name}");
    }

    public void Add(IObject objct)
    {
        _dictionary[objct.Name] = objct;
    }
}