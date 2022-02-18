namespace XpressTest;

public interface IObjectCollection
{
    T Get<T>(string name);
    
    void Add(IObject objct);
}