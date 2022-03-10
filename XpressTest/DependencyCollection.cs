using Moq;

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
    
    public T Get<T>(string name)
        where T : class
    {
        if(_dictionary[name] is T dependency)
        {
            return dependency;
        }

        throw new Exception($"Dependency {name} is not of type {typeof(T).Name}");
    }

    public void Add(IDependency dependency)
    {
        _collection.Add(dependency);
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

    public int Size => _dictionary.Count;
    
    public Mock<T> GetMock<T>() where T : class
    {
        foreach (var dependency in _dictionary)
        {
            if (dependency.Value is MockDependency<T> mockDependency)
            {
                return mockDependency.Mock;
            }
        }

        throw new Exception($"No dependency of type {typeof(T).Name} registered");
    }
}