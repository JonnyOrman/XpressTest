namespace XpressTest;

public interface IArrangement
{
    IObjectCollection Objects { get; }
    
    IDependencyCollection Dependencies { get; }

    T GetObject<T>(string name);
}