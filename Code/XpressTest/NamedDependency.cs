namespace XpressTest;

public class NamedDependency<TDependency>
    :
        Dependency<TDependency>,
        INamedDependency
{
    public NamedDependency(
        TDependency obj,
        string name
        )
    : base(
        obj
        )
    {
        Name = name;
    }

    public string Name { get; }
}