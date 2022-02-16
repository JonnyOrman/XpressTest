namespace XpressTest;

public class ResultTestBuilder<TSut, TResult> : TestBuilder<TSut, Func<TSut, TResult>, Action<TResult>>
    where TSut : class
{
    public ResultTestBuilder(ICollection<IDependency> dependencies) : base(dependencies)
    {
    }

    protected override void ActAndAssert(TSut sut)
    {
        var actualResult = _func.Invoke(sut);

        _assertion.Invoke(actualResult);
    }
}