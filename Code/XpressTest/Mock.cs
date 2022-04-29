namespace XpressTest;

public class Mock<T>
:
    IMock<T>
where T : class
{
    public Mock(
        Moq.Mock<T> moqMock
        )
    {
        MoqMock = moqMock;
    }

    public Moq.Mock<T> MoqMock { get; }

    public T Object => MoqMock.Object;
}