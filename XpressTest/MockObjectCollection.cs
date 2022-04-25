namespace XpressTest;

public class MockObjectCollection : IMockObjectCollection
{
    private readonly IDictionary<string, IMock> _dictionary;
    private readonly ICollection<IMock> _collection;

    public MockObjectCollection(
        IDictionary<string, IMock> dictionary,
        ICollection<IMock> collection
        )
    {
        _dictionary = dictionary;
        _collection = collection;
    }
    
    public void Add<T>(IMock<T> mock) where T : class
    {
        _collection.Add(mock);
    }

    public void Add<T>(INamedMock<T> namedMock) where T : class
    {
        _collection.Add(namedMock);
        _dictionary[namedMock.Name] = namedMock;
    }

    public IMock<TMock> Get<TMock>() where TMock : class
    {
        foreach (var mock in _collection)
        {
            if(mock is IMock<TMock> typedMock)
            {
                return typedMock;
            }
        }
        
        throw new MockNotRegisteredException($"No mock of type {typeof(TMock).Name} registered");
    }

    public IMock<TMock> Get<TMock>(
        string name
        )
        where TMock : class
    {
        if (_dictionary.Any() && _dictionary.ContainsKey(name))
        {
            var mock = _dictionary[name];

            if (mock is IMock<TMock> typedMock)
            {
                return typedMock;
            }
            else
            {
                throw new NamedMockDifferentTypeRegisteredException($"Expected mock with name {name} is not of type {typeof(TMock).Name}");
            }
        }

        throw new NamedMockNotRegisteredException($"No mock of type {typeof(TMock).Name} with name {name} registered");
    }
}