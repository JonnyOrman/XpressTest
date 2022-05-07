namespace XpressTest.Narration;

public class ExpectedResultNarrator<TResult>
:
    IValueNarrator<TResult>
{
    public void Narrate(TResult value)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Then");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" the result should be ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(value);
        Console.ForegroundColor = ConsoleColor.White;
    }
}