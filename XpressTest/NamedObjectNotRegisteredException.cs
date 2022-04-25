namespace XpressTest;

public class NamedObjectNotRegisteredException
    :
        Exception
{
    public NamedObjectNotRegisteredException(
        string message
    ) : base(message)
    {

    }
}