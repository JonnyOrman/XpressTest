namespace XpressTest;

public class ResultTester<TSut, TResult> : Tester<TSut, System.Action<IAssertion<TSut, TResult>>>
    where TSut : class
{
    private readonly Func<IAction<TSut>, TResult> _func;

    public ResultTester(
        Func<IAction<TSut>, TResult> func,
        System.Action<IAssertion<TSut, TResult>> assertion,
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
        
        var actualResult = _func.Invoke(action);

        var assertion = new Assertion<TSut, TResult>(
            actualResult,
            action
            );
        
        _assertion.Invoke(
            assertion
            );
    }
}