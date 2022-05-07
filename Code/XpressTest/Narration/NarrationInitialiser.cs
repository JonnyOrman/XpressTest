namespace XpressTest.Narration;

public static class NarrationInitialiser<TSut>
{
    public static INarrative Initialise()
    {
        var title = TitleProvider.Get();
        
        TitleNarrator.Narrate(title);

        SutNarrator<TSut>.Narrate();

        return new Narrative(title);
    }
}