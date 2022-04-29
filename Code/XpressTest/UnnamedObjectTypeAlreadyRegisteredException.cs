namespace XpressTest;

public class UnnamedObjectTypeAlreadyRegisteredException<TObject>
    :
        Exception
{
    public UnnamedObjectTypeAlreadyRegisteredException()
        :
        base($"An unnamed object of type {typeof(TObject).Name} has already been registered. If more than one object of the same type is registered then they must each be registered with a unique name.")
    {
        ObjectType = typeof(TObject);
    }

    public Type ObjectType { get; }
}