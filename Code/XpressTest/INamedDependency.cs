namespace XpressTest;

public interface INamedDependency
    :
        IDependency
{
    string Name { get; }
}