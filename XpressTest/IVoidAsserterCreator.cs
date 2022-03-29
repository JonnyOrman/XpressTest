namespace XpressTest;

public interface IVoidAsserterCreator<TSut>
{
    IVoidAsserter<TSut> Create(
        System.Action<TSut> action
        );
    
    IVoidAsserter<TSut> Create(
        System.Action<IAction<TSut>> action
        );
}