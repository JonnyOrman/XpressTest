using Moq;

namespace XpressTest;

public interface IMockObjectCollection
{
    void Add<T>(Mock<T> mock)
        where T : class;

    Mock<TMock> Get<TMock>() where TMock : class;
}