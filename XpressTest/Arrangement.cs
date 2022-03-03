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

    public T GetObject<T>() => Objects.Get<T>();

    public T GetObject<T>(string name) => Objects.Get<T>(name);

    public void Add<T>(T obj) => Objects.Add(obj);

    public void Add<T>(INamedObject<T> namedObject) => Objects.Add(namedObject);

    public void Add<T>(Mock<T> mock) where T : class => MockObjects.Add(mock);

    public Mock<TMock> GetMock<TMock>() where TMock : class => MockObjects.Get<TMock>();

    public T GetMockObject<T>() where T : class => GetMock<T>().Object;
}