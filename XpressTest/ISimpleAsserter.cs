namespace XpressTest;

public interface ISimpleAsserter
{
    void ThenItShouldThrow<TException>()
        where TException : Exception;
}
