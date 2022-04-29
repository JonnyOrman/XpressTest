namespace XpressTest;

public class Assertion<TSut, TResult>
    :
        IResultAssertion<TResult>
{

    private readonly ISutArrangement<TSut> _sutArrangement;

    public Assertion(
        TResult result,
        ISutArrangement<TSut> sutArrangement
        )
    {
        Result = result;
        _sutArrangement = sutArrangement;
    }

    public TResult Result { get; }

    public IMock<T> GetTheMock<T>() where T : class => MockObjects.Get<T>();

    public Moq.Mock<TMock> GetTheMoq<TMock>() where TMock : class => GetTheMock<TMock>().MoqMock;

    public IMock<T> GetTheMock<T>(string name) where T : class => MockObjects.Get<T>(name);

    public T GetTheMockObject<T>() where T : class => GetTheMock<T>().Object;

    public T GetTheMockObject<T>(string name) where T : class => GetTheMock<T>(name).Object;

    public IObjectCollection Objects => _sutArrangement.Objects;

    public IMockObjectCollection MockObjects => _sutArrangement.MockObjects;

    public IDependencyCollection Dependencies => _sutArrangement.Dependencies;

    public T GetThe<T>() => Objects.Get<T>();

    public T GetThe<T>(string name) => Objects.Get<T>(name);
}