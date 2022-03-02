namespace XpressTest;

public interface IResultMockCounterVerifier<TSut, TResult>
{
    IResultAsserter<TSut, TResult> Once();
    
    IResultAsserter<TSut, TResult> Never();
}