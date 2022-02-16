namespace XpressTest;

public class VoidTestBuilder<TSut> : TestBuilder<TSut, Action<TSut>, Action>
    where TSut : class
{
    public VoidTestBuilder(ICollection<IDependency> dependencies) : base(dependencies)
    {
    }

    protected override void ActAndAssert(TSut sut)
    {
        _func.Invoke(sut);

        _assertion.Invoke();
    }
}