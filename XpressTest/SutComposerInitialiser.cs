namespace XpressTest;

public static class SutComposerInitialiser<TSut>
{
    public static ISutComposer<TSut> Initialise()
    {
        return new SutComposer<TSut>();
    }
}