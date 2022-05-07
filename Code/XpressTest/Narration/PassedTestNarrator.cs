namespace XpressTest.Narration;

public class PassedTestNarrator
:
    INarrator
{
    private readonly INarrative _narrative;

    public PassedTestNarrator(
        INarrative narrative
        )
    {
        _narrative = narrative;
    }
    
    public void Narrate()
    {
        Console.WriteLine();
        var passedText = "PASSED";
        var passedWidth = _narrative.Title.Length + 6;
        var totalPadding = passedWidth - passedText.Length;
        var dashesEachSide = totalPadding / 2 - 1;
        var dashes = new string('-', dashesEachSide);
        var passedString = dashes + " " + passedText + " " + dashes;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(passedString);
        Console.ForegroundColor = ConsoleColor.White;
    }
}