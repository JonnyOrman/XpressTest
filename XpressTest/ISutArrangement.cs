namespace XpressTest;

public interface ISutArrangement<TSut>
    :
        IReadArrangement
{
    TSut Sut { get; }
}