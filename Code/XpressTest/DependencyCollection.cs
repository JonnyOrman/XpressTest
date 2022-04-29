namespace XpressTest;

public class DependencyCollection : IDependencyCollection
{
    private readonly ICollection<IDependency> _collection;

    public DependencyCollection(
        ICollection<IDependency> collection
        )
    {
        _collection = collection;
    }

    public void Add(IDependency dependency)
    {
        if (dependency != null)
        {
            _collection.Add(dependency);
        }
    }

    public void Add(INamedDependency namedDependency)
    {
        _collection.Add(namedDependency);
    }

    public bool Any()
    {
        return _collection.Any();
    }

    public IEnumerable<IDependency> GetAll()
    {
        return _collection;
    }
}