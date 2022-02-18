namespace XpressTest;

public class VoidTester<TSut> : Tester<TSut, System.Action<IArrangement>>
    where TSut : class
{
    private readonly System.Action<IAction<TSut>> _func;

    public VoidTester(
        System.Action<IAction<TSut>> func,
        System.Action<IArrangement> assertion,
        IDependencyCollection dependencies,
        IObjectCollection objects
        ) : base(
        assertion,
        dependencies,
        objects
        )
    {
        _func = func;
    }
    
    protected override void ActAndAssert(TSut sut)
    {
        var arrangement = new Arrangement(
            _objects,
            _dependencies
        );
        
        var action = new Action<TSut>(
            sut,
            arrangement
        );
        
        _func.Invoke(action);
        
        _assertion.Invoke(arrangement);
    }
}