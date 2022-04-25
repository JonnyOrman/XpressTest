namespace XpressTest;

public class ObjectNotRegisteredException
    :
        Exception
{
    public ObjectNotRegisteredException(
        string message
    ) : base(message)
    {

    }
}