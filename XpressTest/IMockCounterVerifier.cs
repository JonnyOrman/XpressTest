namespace XpressTest;

public interface IMockCounterVerifier<TAsserter>
{
    TAsserter Once();

    TAsserter Never();
}