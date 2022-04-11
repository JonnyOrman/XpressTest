namespace XpressTest;

public class VoidAssertion<TSut> : ISutArrangement<TSut>
{
    private readonly ISutArrangement<TSut> _sutArrangement;

    public VoidAssertion(
        ISutArrangement<TSut> sutArrangement
        )
    {
        _sutArrangement = sutArrangement;
    }

    public IObjectCollection Objects => _sutArrangement.Objects;

    public IMockObjectCollection MockObjects => _sutArrangement.MockObjects;

    public IDependencyCollection Dependencies => _sutArrangement.Dependencies;

    public T GetThe<T>() => Objects.Get<T>();

    public T GetThe<T>(string name) => Objects.Get<T>(name);

    public IMock<T> GetTheMock<T>() where T : class => MockObjects.Get<T>();

    public Moq.Mock<TMock> GetTheMoq<TMock>() where TMock : class => GetTheMock<TMock>().MoqMock;

    public IMock<TMock> GetTheMock<TMock>(string name) where TMock : class => MockObjects.Get<TMock>(name);

    public T GetTheMockObject<T>() where T : class => MockObjects.Get<T>().Object;

    public T GetTheMockObject<T>(string name) where T : class => MockObjects.Get<T>(name).Object;

    public TSut Sut { get; }
}
