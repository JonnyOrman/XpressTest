namespace XpressTest;

public class SutComposer<TSut> : ISutComposer<TSut>
{
    public TSut Compose()
    {
        return Activator.CreateInstance<TSut>();
    }
}