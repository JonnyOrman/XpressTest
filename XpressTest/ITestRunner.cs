namespace XpressTest;

public interface ITestRunner<TSut>
{
    void Run(IAction<TSut> action);
}
