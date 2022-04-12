namespace XpressTest;

public interface ISutArrangementCreator<TSut>
{
    ISutArrangement<TSut> Create();
}