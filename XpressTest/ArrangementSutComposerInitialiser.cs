namespace XpressTest;

public static class ArrangementSutComposerInitialiser<TSut>
    where TSut : class
{
    public static IArrangementSutComposer<TSut> Initialise()
    {
        return new ArrangementSutComposer<TSut>();
    }
}