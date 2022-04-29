namespace XpressTest;

public interface IReadArrangement
{
    IObjectCollection Objects { get; }

    IMockObjectCollection MockObjects { get; }

    IDependencyCollection Dependencies { get; }

    T GetThe<T>();

    T GetThe<T>(string name);

    IMock<TMock> GetTheMock<TMock>()
        where TMock : class;
    Moq.Mock<TMock> GetTheMoq<TMock>()
        where TMock : class;

    IMock<TMock> GetTheMock<TMock>(string name)
        where TMock : class;

    T GetTheMockObject<T>()
        where T : class;

    T GetTheMockObject<T>(string name)
        where T : class;
}