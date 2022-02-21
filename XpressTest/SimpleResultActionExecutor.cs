namespace XpressTest;

public class SimpleResultActionExecutor<TSut, TResult>
    :
        ActionExecutor<Func<TSut, TResult>>,
        ISimpleActionExecutor<TSut, TResult>
{
    public SimpleResultActionExecutor(
        Func<TSut, TResult> action
        ) : base(
        action
        )
    {
    }

    public TResult Execute(TSut sut)
    {
        return _action.Invoke(sut);
    }
}
