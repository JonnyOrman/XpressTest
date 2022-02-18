using Moq;

namespace XpressTest;

public class DependencyCollection : IDependencyCollection
{
    private readonly IDictionary<string, IDependency> _dictionary;

    public DependencyCollection()
    {
        _dictionary = new Dictionary<string, IDependency>();
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
        _dictionary[dependency.Name] = dependency;
    }

    public bool Any()
    {
        return _dictionary.Count > 0;
    }

    public IEnumerable<IDependency> GetAll()
    {
        return _dictionary.Values;
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

        throw new Exception($"No mock of type {typeof(T).Name} registered");
    }
}