using Moq;

namespace XpressTest;

public interface IDependencyCollection
{
    T Get<T>(string name)
        where T : class;
    
    void Add(IDependency dependency);
    
    bool Any();
    
    IEnumerable<IDependency> GetAll();
    
    int Size { get; }

    Mock<T> GetMock<T>()
        where T : class;
}