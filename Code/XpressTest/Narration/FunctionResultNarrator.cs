namespace XpressTest.Narration;

public class FunctionResultNarrator<TResult>
:
    IValueNarrator<TResult>
{
    public void Narrate(TResult result)
    {
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("and returns");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(result);
        Console.ForegroundColor = ConsoleColor.White;
    }
}