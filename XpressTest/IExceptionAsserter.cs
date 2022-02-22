namespace XpressTest;

public interface IExceptionAsserter
{
    void Assert<TException>()
        where TException : Exception;
}
