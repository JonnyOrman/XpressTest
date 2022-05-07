using System.Linq.Expressions;

namespace XpressTest.Narration;

public class ActionNarrator<TSut, TResult>
:
    IActionNarrator<TSut, TResult>
{
    public void Narrate(Expression<Func<TSut, TResult>> action)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("When");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" it ");
        Console.ForegroundColor = ConsoleColor.Blue;
        var methodCall = action.Body as MethodCallExpression;
        Console.Write(methodCall.Method.Name);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" with");
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var arg in methodCall.Arguments)
        {
            Console.Write(" ");
            Console.Write(arg);
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}