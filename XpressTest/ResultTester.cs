namespace XpressTest;

public class ResultTester<TSut, TResult> : Tester<TSut, Action<TResult>>
    where TSut : class
{
    private readonly Func<TSut, TResult> _func;

    public ResultTester(
        Func<TSut, TResult> func,
        Action<TResult> assertion,
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
        var actualResult = _func.Invoke(sut);

        _assertion.Invoke(actualResult);
    }
}