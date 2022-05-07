namespace XpressTest.Narration;

public class FailedTestNarrator
:
    INarrator
{
    private readonly INarrative _narrative;

    public FailedTestNarrator(
        INarrative narrative
        )
    {
        _narrative = narrative;
    }
    
    public void Narrate()
    {
        Console.WriteLine();
        var failedText = "FAILED";
        var failedWidth = _narrative.Title.Length + 6;
        var totalFailedPadding = failedWidth - failedText.Length;
        var failedDashesEachSide = totalFailedPadding / 2 - 1;
        var failedDashes = new string('-', failedDashesEachSide);
        var failedString = failedDashes + " " + failedText + " " + failedDashes;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(failedString);
        Console.ForegroundColor = ConsoleColor.White;
    }
}