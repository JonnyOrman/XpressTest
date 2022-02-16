using Moq;

namespace XpressTest;

public class MockDependency<T> : IDependency
    where T : class
{
    public MockDependency(Mock<T> mock)
    {
        Mock = mock;
    }

    public object Object => Mock.Object;

    public Mock<T> Mock { get; }
}