using Moq;

namespace XpressTest;

public static class NamedMockInitialiser<T>
    where T : class
{
    public static INamedMock<T> Initialise(string name)
    {
        var mock = new Mock<T>();

        return new NamedMock<T>(
            mock,
            name
            );
    }
}
