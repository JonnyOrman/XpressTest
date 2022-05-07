namespace XpressTest.Narration;

public static class SutNarrator<TSut>
{
    public static void Narrate()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Given");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" a ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{typeof(TSut).Name}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}