namespace XpressTest;

public interface IArrangement
{
    IObjectCollection Objects { get; }
    
    IDependencyCollection Dependencies { get; }
}