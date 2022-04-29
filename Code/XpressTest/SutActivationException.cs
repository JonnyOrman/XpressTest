namespace XpressTest;

public class SutActivationException<TSut> : Exception
{
    public SutActivationException()
        : base($"Failed to activate Sut of type {typeof(TSut).Name}")
    {
        SutType = typeof(TSut);
    }

    public Type SutType { get; }
}