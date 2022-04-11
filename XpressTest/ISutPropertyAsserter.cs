namespace XpressTest;

public interface ISutPropertyAsserter<TSut, TProperty>
{
    ISutPropertyTargeter<TSut> ShouldBeNull();
    
    ISutPropertyTargeter<TSut> ShouldBe(TProperty value);
    
    ISutPropertyTargeter<TSut> ShouldBe(Func<ISutArrangement<TSut>, TProperty> func);
}