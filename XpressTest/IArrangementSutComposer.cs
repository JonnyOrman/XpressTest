namespace XpressTest;

public interface IArrangementSutComposer<TSut>
{
    TSut Compose(
        IArrangement arrangement
        );
}
