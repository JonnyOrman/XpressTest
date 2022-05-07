namespace XpressTest.Narration;

public class NamedVariableNarrator
:
    INarrator
{
    private readonly string _name;

    public NamedVariableNarrator(
        string name
        )
    {
        _name = name;
    }
    
    public void Narrate()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"And given ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(_name);
        Console.ForegroundColor = ConsoleColor.White;
    }
}