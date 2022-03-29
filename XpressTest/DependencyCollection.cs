namespace XpressTest;

public class DependencyCollection : IDependencyCollection
{
    private readonly IDictionary<string, IDependency> _dictionary;
    private readonly ICollection<IDependency> _collection;

    public DependencyCollection()
    {
        _dictionary = new Dictionary<string, IDependency>();
        _collection = new List<IDependency>();
    }
    
    public void Add(IDependency dependency)
    {
        if (dependency != null)
        {
            _collection.Add(dependency);
        }
    }
    
    public void Add(INamedDependency dependency)
    {
        _dictionary[dependency.Name] = dependency;
        
        _collection.Add(dependency);
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