using Moq;

namespace XpressTest;

public class MockObjectCollection : IMockObjectCollection
{
    private readonly IDictionary<string, Mock> _dictionary;
    private readonly ICollection<Mock> _collection;

    public MockObjectCollection()
    {
        _dictionary = new Dictionary<string, Mock>();
        _collection = new List<Mock>();
    }
    
    public void Add<T>(Mock<T> mock) where T : class
    {
        _collection.Add(mock);
    }

    public void Add<T>(INamedMock<T> namedMock) where T : class
    {
        _dictionary[namedMock.Name] = namedMock.Mock;
    }

    public Mock<TMock> Get<TMock>() where TMock : class
    {
        foreach (var mock in _collection)
        {
            if(mock is Mock<TMock> typedMock)
            {
                return typedMock;
            }
        }
        
        throw new Exception($"No mock of type {typeof(TMock).Name} registered");
    }

    public Mock<TMock> Get<TMock>(
        string name
        )
        where TMock : class
    {
        var mock = _dictionary[name];

        var castMock = mock as Mock<TMock>;

        return castMock;
    }
}