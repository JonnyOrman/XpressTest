namespace XpressTest;

public static class AsserterCreatorInitialiser<TSut>
where TSut : class
{
    public static IAsserterCreator<TSut> Initialise(
        IArrangement arrangement
        )
    {
        var sutComposer = new ArrangementSutComposer<TSut>(
            arrangement
        );
        
        var sutArrangementCreator = new SutArrangementCreator<TSut>(
            sutComposer,
            arrangement
        );
        
        var resultAsserterCreator = new ResultAsserterCreator<TSut>(
            sutArrangementCreator
        );
        
        var voidAsserterCreator = new VoidAsserterCreator<TSut>(
            sutArrangementCreator
        );

        var sutAsserterCreator = new SutAsserterCreator<TSut>(
            sutArrangementCreator
        );

        return new AsserterCreator<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            sutAsserterCreator
        );
    }
}