namespace XpressTest.Narration;

public class Narrative
:
    INarrative
{
    public Narrative(
        string title
        )
    {
        Title = title;
    }
    
    public string Title { get; }
}