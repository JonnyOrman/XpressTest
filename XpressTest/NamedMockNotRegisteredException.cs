namespace XpressTest;

public class NamedMockNotRegisteredException : Exception
{
    public NamedMockNotRegisteredException(
        string message
        ) : base(message)
    {
        
    }
}