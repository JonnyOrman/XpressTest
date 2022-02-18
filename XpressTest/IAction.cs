namespace XpressTest;

public interface IAction<TSut> : IArrangement
{
    TSut Sut { get; }
    
    IArrangement Arrangement { get; }
}