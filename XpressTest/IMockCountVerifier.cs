namespace XpressTest;

public interface IMockCountVerifier<TAsserter>
{
    TAsserter Once();

    TAsserter Never();
}