namespace XpressTest;

public class ExceptionNotThrownException : Exception
{
    public ExceptionNotThrownException(
        string message
        ) : base(message)
    {
        
    }
}