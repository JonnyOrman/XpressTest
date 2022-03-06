namespace XpressTest;

public static class ResultAsserterComposerInitialiser<TSut>
    where TSut : class
{
    public static IResultAsserterComposer<TSut> Initialise()
    {
        var sutComposer = SutComposerInitialiser<TSut>.Initialise();
        
        return new ResultAsserterComposer<TSut>(
            sutComposer
            );
    }
}