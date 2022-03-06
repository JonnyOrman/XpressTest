namespace XpressTest;

public static class SutComposerInitialiser<TSut>
    where TSut : class
{
    public static ISutComposer<TSut> Initialise()
    {
        return new SutComposer<TSut>();
    }
}