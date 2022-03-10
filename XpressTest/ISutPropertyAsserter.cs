namespace XpressTest;

public interface ISutPropertyAsserter<TSut, TProperty>
{
    ISutPropertyTargeter<TSut> ShouldBeNull();
    
    ISutPropertyTargeter<TSut> ShouldBe(TProperty value);
}