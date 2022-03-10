using Moq;

namespace XpressTest;

public class NamedMock<T> : INamedMock<T>
    where T : class
{
    public Mock<T> Mock { get; }
    
    public T Object => Mock.Object;
    
    public string Name { get; }

    public NamedMock(
        Mock<T> mock,
        string name
        )
    {
        Mock = mock;
        Name = name;
    }
}
