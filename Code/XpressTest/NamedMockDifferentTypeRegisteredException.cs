namespace XpressTest;

public class NamedMockDifferentTypeRegisteredException<TExpectedType>
    :
        Exception
{
    public NamedMockDifferentTypeRegisteredException(
        string name,
        Type actualType
        ) : base($"Expected mock with name {name} to be of type {typeof(TExpectedType).Name} but is actually of type {actualType.Name}")
    {
        ExpectedType = typeof(TExpectedType);
        ActualType = actualType;
    }

    public Type ExpectedType { get; }

    public Type ActualType { get; }
}