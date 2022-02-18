using Moq;

namespace XpressTest;

public class MockDependency<T> : IDependency
    where T : class
{
    public MockDependency(Mock<T> mock)
    {
        Mock = mock;
        Name = typeof(T).Name;
    }

    public object Object => Mock.Object;
    
    public string Name { get; }

    public Mock<T> Mock { get; }
}