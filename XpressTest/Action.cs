namespace XpressTest;

public class Action<TSut> : IAction<TSut>
{
    public Action(
        TSut sut,
        IArrangement arrangement
        )
    {
        Sut = sut;
        Arrangement = arrangement;
    }

    public TSut Sut { get; }
    
    public IArrangement Arrangement { get; }

    public IObjectCollection Objects => Arrangement.Objects;

    public IDependencyCollection Dependencies => Arrangement.Dependencies;
}