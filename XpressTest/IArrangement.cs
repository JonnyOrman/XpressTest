using Moq;

namespace XpressTest;

public interface IArrangement
{
    IObjectCollection Objects { get; }
    
    IDependencyCollection Dependencies { get; }

    T GetObject<T>();

    T GetObject<T>(string name);

    void Add<T>(T obj);

    void Add<T>(INamedObject<T> namedObject);
    
    Mock<TMock> GetMock<TMock>() where TMock : class;
}