namespace XpressTest;

public static class SutActionInitialiser<TSut>
    where TSut : class
{
    public static ISutPropertyTargeter<TSut> Initialise()
    {
        var sut = Activator.CreateInstance<TSut>();

        var sutPropertyTargeter = new SutPropertyTargeter<TSut>(
            sut
            );
        
        return new SutAsserter<TSut>(
            sutPropertyTargeter
            );
    }
}