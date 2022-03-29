using Moq;

namespace XpressTest;

public interface INamedMock<T>
    :
        INamedObject<T>
    where T : class
{
    Mock<T> Mock { get; }
}
