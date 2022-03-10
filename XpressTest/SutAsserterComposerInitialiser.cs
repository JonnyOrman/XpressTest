namespace XpressTest;

public static class SutAsserterComposerInitialiser<TSut>
    where TSut : class
{
    public static ISutAsserterComposer<TSut> Initialise()
    {
        var sutComposer = ArrangementSutComposerInitialiser<TSut>.Initialise();

        return new SutAsserterComposer<TSut>(
            sutComposer
        );
    }
}