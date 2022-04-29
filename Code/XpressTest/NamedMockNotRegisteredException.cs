namespace XpressTest;

public class NamedMockNotRegisteredException<TMock> : Exception
{
    public NamedMockNotRegisteredException(
        string name
        ) : base($"No mock of type {typeof(TMock).Name} with name {name} registered")
    {
        MockType = typeof(TMock);
    }

    public Type MockType { get; }
}