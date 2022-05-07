namespace XpressTest.Narration;

public class InvalidResultNarrator<TResult>
:
    IValueNarrator<TResult>
{
    public void Narrate(TResult result)
    {
        Console.Write(" ");
        Console.Write("\u274c");
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("but was ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(result);
        Console.ForegroundColor = ConsoleColor.White;
    }
}