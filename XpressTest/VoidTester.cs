namespace XpressTest;

public class VoidTester<TSut> : Tester<TSut, Action>
    where TSut : class
{
    private readonly Action<TSut> _func;

    public VoidTester(
        Action<TSut> func,
        Action assertion,
        ICollection<IDependency> dependencies
        ) : base(
        assertion,
        dependencies
        )
    {
        _func = func;
    }
    
    protected override void ActAndAssert(TSut sut)
    {
        _func.Invoke(sut);
        
        _assertion.Invoke();
    }
}