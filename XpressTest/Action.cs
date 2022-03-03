namespace XpressTest;

public class Action<TSut> : Arrangement, IAction<TSut>
{
    public Action(
        TSut sut,
        IArrangement arrangement
        ) :base(
        arrangement.Objects,
        arrangement.MockObjects,
        arrangement.Dependencies
        )
    {
        Sut = sut;
    }

    public TSut Sut { get; }
}