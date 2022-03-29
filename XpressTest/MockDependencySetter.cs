using Moq;

namespace XpressTest;

public class MockDependencySetter<TDependency>
    :
        IObjectSetter<Mock<TDependency>>
where TDependency : class
{
    private readonly IArrangement _arrangement;

    public MockDependencySetter(
        IArrangement arrangement
        )
    {
        _arrangement = arrangement;
    }
    
    public void Set(Mock<TDependency> dependencyMock)
    {
        _arrangement.Add(dependencyMock);
        _arrangement.AddDependency(dependencyMock.Object);
    }
}