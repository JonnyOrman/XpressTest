namespace XpressTest;

public class ExceptionNotThrownException<TException> : Exception
{
    public ExceptionNotThrownException()
        :
        base($"An Exception of type {typeof(TException).Name} was not thrown")
    {
        ExpectedExceptionType = typeof(TException);
    }

    public Type ExpectedExceptionType { get; }
}