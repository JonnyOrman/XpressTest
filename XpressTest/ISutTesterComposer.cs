namespace XpressTest;

public interface ISutTesterComposer<TSut, TAssertion>
{
    ISutTester<TSut> Compose(TAssertion assertion);
}
