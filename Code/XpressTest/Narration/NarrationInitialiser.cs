using System.Diagnostics;

namespace XpressTest.Narration;

public static class NarrationInitialiser<TSut>
{
    public static INarrative Initialise()
    {
        var stackTrace = new StackTrace();
        var title = stackTrace.GetFrame(2).GetMethod().Name;
        
        TitleNarrator.Narrate(title);

        SutNarrator<TSut>.Narrate();

        return new Narrative(title);
    }
}