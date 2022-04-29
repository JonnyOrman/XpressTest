namespace XpressTest;

public class MockNotRegisteredException<TMock> : Exception
{
    public MockNotRegisteredException()
        :
        base($"No mock of type {typeof(TMock).Name} registered")
    {
        MockType = typeof(TMock);
    }

    public Type MockType { get; }
}