namespace XpressTest;

public interface INamedObject<T>
:
    IObject<T>
{
    string Name { get; }
}
