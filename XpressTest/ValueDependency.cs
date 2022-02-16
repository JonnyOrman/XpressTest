namespace XpressTest;

public class ValueDependency<T> : IDependency
{
    public ValueDependency(T obj)
    {
        Object = obj;
    }

    public object Object { get; }
}