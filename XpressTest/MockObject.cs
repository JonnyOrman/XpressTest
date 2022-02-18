using Moq;

namespace XpressTest;

public class MockObject<T> : IObject
    where T : class
{
    private readonly Mock<T> _objectMock;

    public MockObject(
        Mock<T> objectMock,
        string name)
    {
        _objectMock = objectMock;
        Name = name;
    }

    public string Name { get; }

    public object Obj => _objectMock.Object;
}