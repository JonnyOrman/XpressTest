namespace XpressTest;

public interface IObjectCollection
{
    T Get<T>(string name);

    T Get<T>();

    void Add<T>(INamedObject<T> namedObject);

    void Add<T>(T obj);
}