namespace XpressTest;

public class SimpleVoidAsserter : ISimpleAsserter
{
    private readonly IExceptionAsserter _exceptionAsserter;

    public SimpleVoidAsserter(
        IExceptionAsserter exceptionAsserter
        )
    {
        _exceptionAsserter = exceptionAsserter;
    }

    public void ThenItShouldThrow<TException>()
        where TException : Exception
    {
        _exceptionAsserter.Assert<TException>();
    }
}
