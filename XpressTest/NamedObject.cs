namespace XpressTest;

public class NamedObject<T>
    :
        INamedObject<T>
{
    public NamedObject(
        T obj,
        string name
        )
    {
        Object = obj;
        Name = name;
    }

    public T Object { get; }
    
    public string Name { get; }
}
