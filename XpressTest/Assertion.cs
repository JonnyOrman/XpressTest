namespace XpressTest;

public class Assertion<TSut, TResult>
    :
        IResultAssertion<TResult>
{
    public Assertion(
        TResult result,
        ISutArrangement<TSut> action
        )
    {
        Result = result;
        Action = action;
    }
    
    public TResult Result { get; }

    public IMock<T> GetTheMock<T>() where T : class => MockObjects.Get<T>();

    public Moq.Mock<TMock> GetTheMoq<TMock>() where TMock : class => GetTheMock<TMock>().MoqMock;

    public IMock<T> GetTheMock<T>(string name) where T : class => MockObjects.Get<T>(name);
    
    public T GetTheMockObject<T>() where T : class => GetTheMock<T>().Object;

    public T GetTheMockObject<T>(string name) where T : class => GetTheMock<T>(name).Object;

    public IObjectCollection Objects => Action.Objects;

    public IMockObjectCollection MockObjects => Action.MockObjects;

    public IDependencyCollection Dependencies => Action.Dependencies;

    public T GetThe<T>() => Objects.Get<T>();

    public T GetThe<T>(string name) => Objects.Get<T>(name);

    private ISutArrangement<TSut> Action { get; }
}