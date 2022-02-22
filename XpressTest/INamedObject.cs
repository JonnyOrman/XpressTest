namespace XpressTest;

public interface INamedObject<T>
{
    T Object { get; }

    string Name { get; }
}
