using Moq;

namespace XpressTest;

public class VoidAssertion<TSut> : IAssertion<TSut>
{
    public VoidAssertion(
        IAction<TSut> action
        )
    {
        Action = action;
    }

    public IObjectCollection Objects => Action.Objects;

    public IDependencyCollection Dependencies => Action.Dependencies;

    public T GetObject<T>(string name) => Objects.Get<T>(name);
    
    public void Add<T>(INamedObject<T> obj) => Objects.Add(obj);

    public IAction<TSut> Action { get; }

    public Mock<T> GetMock<T>() where T : class => Dependencies.GetMock<T>();
}
