namespace XpressTest;

public static class ActionInitialiser<TSut>
{
    public static void Initialise(System.Action<TSut> action)
    {
        var sut = Activator.CreateInstance<TSut>();

        action.Invoke(sut);
    }
}
