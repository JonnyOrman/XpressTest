using Moq;

namespace XpressTest;

public class Arrangement : IArrangement
{
    public Arrangement(
        IObjectCollection objects,
        IMockObjectCollection mockObjects,
        IDependencyCollection dependencies
        )
    {
        MockObjects = mockObjects;
        Objects = objects;
        Dependencies = dependencies;
    }

    public IMockObjectCollection MockObjects { get; }

    public IObjectCollection Objects { get; }
    
    public IDependencyCollection Dependencies { get; }

    public T GetThe<T>() => Objects.Get<T>();

    public T GetObject<T>(string name) => Objects.Get<T>(name);

    public void Add<T>(T obj) => Objects.Add(obj);

    public void Add<T>(INamedObject<T> namedObject) => Objects.Add(namedObject);

    public void Add<T>(Mock<T> mock) where T : class => MockObjects.Add(mock);

    public void Add<T>(INamedMock<T> mock) where T : class => MockObjects.Add(mock);

    public Mock<TMock> GetMock<TMock>() where TMock : class => MockObjects.Get<TMock>();
    
    public Mock<TMock> GetMock<TMock>(string name) where TMock : class => MockObjects.Get<TMock>(name);

    public T GetMockObject<T>() where T : class => GetMock<T>().Object;

    public T GetMockObject<T>(string name) where T : class => GetMock<T>(name).Object;

    public void AddDependency<TDependency>(TDependency dependency)
    {
        var dependencyObject = new Dependency<TDependency>(dependency);
        
        Dependencies.Add(dependencyObject);
    }
    
    public void AddDependency<TDependency>(TDependency dependency, string name)
    {
        var dependencyObject = new NamedDependency<TDependency>(
            dependency,
            name
            );
        
        Dependencies.Add(dependencyObject);
    }
}