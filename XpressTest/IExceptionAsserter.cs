namespace XpressTest;

public interface IExceptionAsserter
{
    void ThenItShouldThrow<TException>()
        where TException : Exception;
}
