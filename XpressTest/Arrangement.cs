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

    public T GetThe<T>(string name) => Objects.Get<T>(name);

    public void Add<T>(T obj) => Objects.Add(obj);

    public void Add<T>(INamedObject<T> namedObject) => Objects.Add(namedObject);

    public void Add<T>(IMock<T> mock) where T : class => MockObjects.Add(mock);

    public void Add<T>(INamedMock<T> mock) where T : class => MockObjects.Add(mock);

    public IMock<TMock> GetTheMock<TMock>() where TMock : class => MockObjects.Get<TMock>();

    public Moq.Mock<TMock> GetTheMoq<TMock>() where TMock : class => GetTheMock<TMock>().MoqMock;

    public IMock<TMock> GetTheMock<TMock>(string name) where TMock : class => MockObjects.Get<TMock>(name);

    public T GetTheMockObject<T>() where T : class => GetTheMock<T>().Object;

    public T GetTheMockObject<T>(string name) where T : class => GetTheMock<T>(name).Object;

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