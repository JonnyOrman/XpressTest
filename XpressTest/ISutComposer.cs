namespace XpressTest;

public interface ISutComposer<TSut>
{
    TSut Compose(
        IArrangement arrangement
        );
}
