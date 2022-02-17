using Moq;

namespace XpressTest;

public class MockDependency<T> : IDependency
    where T : class
{
    private readonly Mock _mock;
    
    public MockDependency(Mock<T> mock)
    {
        _mock = mock;
    }

    public object Object => _mock.Object;
}