using Moq;

namespace XpressTest;

public class Assertion<TSut, TResult> : IAssertion<TSut, TResult>
{
    public Assertion(
        TResult result,
        IAction<TSut> action
        )
    {
        Result = result;
        Action = action;
    }
    
    public TResult Result { get; }
    
    public IAction<TSut> Action { get; }

    public void Add<T>(Mock<T> mock) where T : class => MockObjects.Add(mock);

    public Mock<T> GetMock<T>() where T : class => Dependencies.GetMock<T>();
    
    public T GetMockObject<T>()
        where T : class
    {
        throw new NotImplementedException();
    }

    public IObjectCollection Objects => Action.Objects;

    public IMockObjectCollection MockObjects => Action.MockObjects;

    public IDependencyCollection Dependencies => Action.Dependencies;

    public T GetObject<T>() => Objects.Get<T>();

    public T GetObject<T>(string name) => Objects.Get<T>(name);

    public void Add<T>(T obj) => Objects.Add(obj);

    public void Add<T>(INamedObject<T> obj) => Objects.Add(obj);
}