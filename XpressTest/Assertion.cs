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

    public Mock<T> GetMock<T>() where T : class => Dependencies.GetMock<T>();

    public IObjectCollection Objects => Action.Objects;

    public IDependencyCollection Dependencies => Action.Dependencies;

    public T GetObject<T>(string name) => Objects.Get<T>(name);
    
    public void Add<T>(INamedObject<T> obj) => Objects.Add(obj);
}