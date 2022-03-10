using Moq;

namespace XpressTest;

public interface IArrangement
{
    IObjectCollection Objects { get; }
    
    IMockObjectCollection MockObjects { get; }
    
    IDependencyCollection Dependencies { get; }

    T GetThe<T>();

    T GetObject<T>(string name);

    void Add<T>(T obj);

    void Add<T>(INamedObject<T> namedObject);
    
    void Add<T>(Mock<T> mock)
        where T : class;

    Mock<TMock> GetMock<TMock>()
        where TMock : class;

    T GetMockObject<T>()
        where T : class;

    void AddDependency<TDependency>(TDependency dependency);
    
    void AddDependency<TDependency>(TDependency dependency, string name);
}