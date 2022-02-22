namespace XpressTest;

public class Action<TSut> : Arrangement, IAction<TSut>
{
    public Action(
        TSut sut,
        IArrangement arrangement
        ) :base(
        arrangement.Objects,
        arrangement.Dependencies
        )
    {
        Sut = sut;
        Arrangement = arrangement;
    }

    public TSut Sut { get; }
    
    public IArrangement Arrangement { get; }
}