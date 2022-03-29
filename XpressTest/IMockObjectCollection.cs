using Moq;

namespace XpressTest;

public interface IMockObjectCollection
{
    void Add<T>(Mock<T> mock)
        where T : class;
    
    void Add<T>(INamedMock<T> mock)
        where T : class;

    Mock<TMock> Get<TMock>() where TMock : class;
    
    Mock<TMock> Get<TMock>(string name) where TMock : class;
}