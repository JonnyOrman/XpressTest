namespace XpressTest;

public class Dependency<T> : IDependency
{
    public Dependency(T obj)
    {
        Object = obj;
    }

    public object Object { get; }
}