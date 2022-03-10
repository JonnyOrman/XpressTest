namespace XpressTest;

public interface IVoidAsserterComposer<TSut>
{
    IVoidAsserter<TSut> Compose(
        System.Action<TSut> action,
        IArrangement arrangement);
    
    IVoidAsserter<TSut> Compose(
        System.Action<IAction<TSut>> action,
        IArrangement arrangement);
}