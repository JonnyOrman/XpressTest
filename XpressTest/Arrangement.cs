namespace XpressTest;

public class Arrangement : IArrangement
{
    public Arrangement(
        IObjectCollection objects,
        IDependencyCollection dependencies
        )
    {
        Objects = objects;
        Dependencies = dependencies;
    }

    public IObjectCollection Objects { get; }
    
    public IDependencyCollection Dependencies { get; }

    public T GetObject<T>() => Objects.Get<T>();

    public T GetObject<T>(string name) => Objects.Get<T>(name);

    public void Add<T>(T obj) => Objects.Add(obj);

    public void Add<T>(INamedObject<T> namedObject) => Objects.Add(namedObject);
}