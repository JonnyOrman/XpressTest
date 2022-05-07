namespace XpressTest.Narration;

public static class TitleNarrator
{
    public static void Narrate(string title)
    {
        var titleLine = $"-- {title} --";
        var titleWidth = titleLine.Length;
        var titleBorder = new string('-', titleWidth);
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(titleBorder);
        Console.WriteLine(titleLine);
        Console.WriteLine(titleBorder);
    }
}