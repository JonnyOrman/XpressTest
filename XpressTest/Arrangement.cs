namespace XpressTest;

public class Arrangement : IArrangement
{
    public Arrangement(
        IObjectCollection objects,
        IDependencyCollection dependencies
        )
    {
        Objects = objects;
        Dependencies = dependencies;
    }

    public IObjectCollection Objects { get; }
    
    public IDependencyCollection Dependencies { get; }
}