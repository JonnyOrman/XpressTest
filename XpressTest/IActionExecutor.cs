namespace XpressTest;

public interface IActionExecutor<TSut, TAssertion>
{
    TAssertion Execute(IAction<TSut> action);
}
