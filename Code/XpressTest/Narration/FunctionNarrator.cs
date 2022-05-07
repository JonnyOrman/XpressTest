using System.Linq.Expressions;

namespace XpressTest.Narration;

public class FunctionNarrator<TObject>
    :
        IFunctionNarrator<TObject>
{
    public void Narrate<TResult>(
        Expression<Func<TObject, TResult>> expression
        )
    {
        var methodCall = expression.Body as MethodCallExpression;
        var methodName = methodCall.Method.Name;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"That does ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(methodName);
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