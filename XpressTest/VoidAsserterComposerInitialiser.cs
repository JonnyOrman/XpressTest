namespace XpressTest;

public static class VoidAsserterComposerInitialiser<TSut>
    where TSut : class
{
    public static IVoidAsserterComposer<TSut> Initialise()
    {
        var sutComposer = SutComposerInitialiser<TSut>.Initialise();

        return new VoidAsserterComposer<TSut>(
            sutComposer
            );
    }
}