namespace XpressTest;

public interface IMockObjectCollection
{
    void Add<T>(IMock<T> mock)
        where T : class;
    
    void Add<T>(INamedMock<T> mock)
        where T : class;

    IMock<TMock> Get<TMock>() where TMock : class;
    
    IMock<TMock> Get<TMock>(string name) where TMock : class;
}