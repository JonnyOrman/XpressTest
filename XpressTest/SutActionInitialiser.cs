namespace XpressTest;

public static class SutActionInitialiser<TSut>
    where TSut : class
{
    public static ISutAsserter<TSut> Initialise()
    {
        var sutComposer = SutComposerInitialiser<TSut>.Initialise();

        var sut = sutComposer.Compose();
        
        var sutPropertyTargeter = new SutPropertyTargeter<TSut>(
            sut
            );
        
        return new SutAsserter<TSut>(
            sutPropertyTargeter
            );
    }
}