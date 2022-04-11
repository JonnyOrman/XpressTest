namespace XpressTest;

public interface IVoidAsserterCreator<TSut>
{
    IVoidAsserter<TSut> Create(
        Action<TSut> action
        );
    
    IVoidAsserter<TSut> Create(
        Action<ISutArrangement<TSut>> action
        );
}