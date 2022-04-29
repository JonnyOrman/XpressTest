namespace XpressTest;

public class NamedMock<T>
    :
        INamedMock<T>
    where T : class
{
    public NamedMock(
        Moq.Mock<T> mock,
        string name
        )
    {
        MoqMock = mock;
        Name = name;
    }

    public Moq.Mock<T> MoqMock { get; }

    public T Object => MoqMock.Object;

    public string Name { get; }

}
