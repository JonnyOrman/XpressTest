namespace XpressTest;

public class NamedObjectDifferentTypeRegisteredException<TExpectedType>
    :
        Exception
{
    public NamedObjectDifferentTypeRegisteredException(
        string name,
        Type actualType
    ) : base($"Expected object with name {name} to be of type {typeof(TExpectedType).Name} but is actually of type {actualType.Name}")
    {
        ExpectedType = typeof(TExpectedType);
        ActualType = actualType;
    }

    public Type ExpectedType { get; }

    public Type ActualType { get; }
}