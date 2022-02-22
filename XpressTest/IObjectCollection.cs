namespace XpressTest;

public interface IObjectCollection
{
    T Get<T>(string name);
    
    void Add<T>(INamedObject<T> namedObject);
}