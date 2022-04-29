namespace XpressTest;

public class SutArrangement<TSut> : Arrangement, ISutArrangement<TSut>
{
    public SutArrangement(
        TSut sut,
        IArrangement arrangement
        ) : base(
        arrangement.Objects,
        arrangement.MockObjects,
        arrangement.Dependencies
        )
    {
        Sut = sut;
    }

    public TSut Sut { get; }
}