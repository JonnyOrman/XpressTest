namespace XpressTest;

public class Dependency<T> : IDependency
{
    public Dependency(
        T obj)
    {
        Object = obj;
        Name = typeof(T).Name;
    }
    
    public Dependency(
        T obj,
        string name)
    {
        Object = obj;
        Name = name;
    }

    public object Object { get; }
    public string Name { get; }
}