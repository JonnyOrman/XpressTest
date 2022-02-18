namespace XpressTest;

public class Object<T> : IObject
{
    public Object(
        T obj,
        string name
        )
    {
        Obj = obj;
        Name = name;
    }

    public string Name { get; }
    
    public object Obj { get; }
}