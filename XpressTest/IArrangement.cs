using Moq;

namespace XpressTest;

public interface IArrangement
{
    IObjectCollection Objects { get; }
    
    IMockObjectCollection MockObjects { get; }
    
    IDependencyCollection Dependencies { get; }

    T GetObject<T>();

    T GetObject<T>(string name);

    void Add<T>(T obj);

    void Add<T>(INamedObject<T> namedObject);
    
    void Add<T>(Mock<T> mock)
        where T : class;
    
    Mock<TMock> GetMock<TMock>() where TMock : class;

    T GetMockObject<T>()
        where T : class;
}